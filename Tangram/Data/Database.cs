using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using Tangram.Data.DataModels;
using System.Data;

namespace Tangram.Data
{
    class Database
    {
        static private MySqlConnection connection = new MySqlConnection() {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mysql_connection"].ToString()
        };
        static private MySqlCommand command = new MySqlCommand()
        {
            Connection = connection
        };

        public static UserRepository userRepository;
        public static GroupsRepository GroupsRepository;
        public static GroupTypeRepository GroupTypeRepository;
        public static ChildrenRepository ChildrenRepository;

        public static TeacherWorkspace Teacher_Workspace;
        public static MetWorkspace MetWorkspace;

       //static public DataTable statistics = new DataTable();

       static public  bool Open()
        {
            try
            {
                connection.Open();
                //TableInfoHolder.Init();
                userRepository = new UserRepository(connection);
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
            
        }

        static public void Close()
        {
            connection.Close();
        }


        static public void  Init(User user)
        {
            //GroupsRepository?.Dispose();
            //GroupTypeRepository?.Dispose();
            //ChildrenRepository?.Dispose();
            Teacher_Workspace?.Dispose();
            MetWorkspace?.Dispose();

            switch (user.UserType)
            {
                case User.UserTypes.MET:
                    //GroupsRepository = new GroupsRepository(connection);
                    //GroupTypeRepository = new GroupTypeRepository(connection);
                    //ChildrenRepository = new ChildrenRepository(connection);
                    MetWorkspace = new MetWorkspace(connection, user);
                    break;
                case User.UserTypes.VOSP:
                   Teacher_Workspace = new TeacherWorkspace(connection, user);
                    break;
            }
        }


        public struct Statistics {

            public DataTable mainResult;
            public DataTable attendance;

            public int low_count_diff1;
            public int mid_count_diff1;
            public int hight_count_diff1;

            public int low_count_diff2;
            public int mid_count_diff2;
            public int hight_count_diff2;

        }

        public static Statistics GetStatistics(int id_group_h,DateTime start, DateTime end)
        {
            Statistics st = new Statistics();

            st.mainResult = new DataTable();

            int userId = 0;

            switch (userRepository.currentUser.UserType)
            {
                case User.UserTypes.MET:
                    command.CommandText = "select id_user from group_history where id_group_h = '" + id_group_h + "'";
                    Object res = command.ExecuteScalar();
                    if (res != null)
                    {
                        userId = Convert.ToInt32(res);
                    }
                    break;
                case User.UserTypes.VOSP:
                    userId = userRepository.currentUser.Id;
                    break;
            }

            command.CommandText =String.Format(@"select childs.id_child,
                                           concat(childs.name, ' ', childs.fam) as 'childName',
	                                      (select avg(results.score)
                                           from results
                                           inner join classes on classes.id_class = results.id_class
                                           where results.id_child = childs.id_child and id_level = 1 and
                                           classes.class_date between '{0}' and '{1}') as 'diff_1_result',
	                                       (select avg(results.score)
                                            from results
                                            inner join classes on classes.id_class = results.id_class
                                            where results.id_child = childs.id_child and id_level = 2 and
                                            classes.class_date between '{0}' and '{1}') as 'diff_2_result',
                                         (select count(distinct results.id_class) 
                                          from results
		                                  inner join classes on  classes.id_class = results.id_class
		                                  where results.id_child = childs.id_child and
                                          classes.class_date between '{0}' and '{1}') as 'classCount'
                                   from childs
                                   inner join child_journal on child_journal.id_child = childs.id_child
                                   inner
                                   join group_history on child_journal.id_group_h = group_history.id_group_h
                                   where group_history.id_group_h = '{2}' order by childName", start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"),
                                   id_group_h);

            using(MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                command.ExecuteNonQuery();
                adapter.Fill(st.mainResult);
            }

            st.attendance = new DataTable();
            st.attendance.Columns.Add("child_name", typeof(string));


            Dictionary<int, string> classes = new Dictionary<int, string>();
            command.CommandText = String.Format("select id_class, class_date from classes where id_user = '{0}' and " +
                                  "classes.class_date between '{1}' and '{2}'", userId, start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    classes.Add(reader.GetInt32(0), reader.GetString(1));
                    st.attendance.Columns.Add(classes.Last().Value, typeof(string));
                }
            }


            command.CommandText = String.Format("select count(*) from classes where id_user = '{0}' and " +
                                  "classes.class_date between '{1}' and '{2}'", userId, start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));

            int totalClassCount = Convert.ToInt32(command.ExecuteScalar());

            //table.Columns.Add(new DataColumn("diff_1_res_text", typeof(string)));
            //table.Columns.Add(new DataColumn("diff_2_res_text", typeof(string)));
            st.mainResult.Columns.Add(new DataColumn("classCount_text", typeof(string)));

            st.low_count_diff1 = 0;
            st.mid_count_diff1 = 0;
            st.hight_count_diff1 = 0;

            st.low_count_diff2 = 0;
            st.mid_count_diff2 = 0;
            st.hight_count_diff2 = 0;

            foreach (DataRow row in st.mainResult.Rows)
            {
                st.attendance.Rows.Add(row["childName"]);
                row["classCount_text"] = row["classCount"].ToString() + " из " + totalClassCount;

                if(row["diff_1_result"]!=DBNull.Value && row["diff_1_result"] != null)
                {
                    int res = Convert.ToInt32(row["diff_1_result"]);
                    if (res <= 4)
                    {
                        st.low_count_diff1++;
                    }
                    if(res>4 && res <= 7)
                    {
                        st.mid_count_diff1++;
                    }
                    if (res > 7)
                    {
                        st.hight_count_diff1++;
                    }

                }

                if (row["diff_2_result"] != DBNull.Value && row["diff_2_result"] != null)
                {
                    int res = Convert.ToInt32(row["diff_2_result"]);
                    if (res <= 4)
                    {
                        st.low_count_diff2++;
                    }
                    if (res > 4 && res <= 7)
                    {
                        st.mid_count_diff2++;
                    }
                    if (res > 7)
                    {
                        st.hight_count_diff2++;
                    }

                }
            }


            
            foreach(var classItem in classes)
            {
                int i = 0;
                foreach (DataRow row in st.mainResult.Rows)
                {
                    
                    command.CommandText = String.Format(@"select id_result from results where id_class='{0}' and id_child='{1}'", 
                                                         classItem.Key.ToString(), 
                                                         row["id_child"].ToString());
                    st.attendance.Rows[i][classItem.Value] = command.ExecuteScalar() != null ? "+":"-";
                    i++;
                }
            }


            return st;
        }


        //public enum AuthResult{
        //      AUTH_FAIL,
        //      AUTH_PASS,
        //      EXCEPTION
        //  }

        // static public AuthResult Auth(string login, string password)
        //  {




        //      //string hash = User.getHash(password);
        //      ////string hash = password;
        //      //try
        //      //{

        //      //        command.CommandText = String.Format("select user_id,fam,name, otch,phone, role_id from users where login = '{0}' and password='{1}'", login, hash);
        //      //        using (MySqlDataReader reader = command.ExecuteReader())
        //      //        {
        //      //            if (reader.HasRows)
        //      //            {

        //      //                reader.Read();
        //      //                int id = Convert.ToInt32(reader["user_id"]);
        //      //                string fam = reader.GetString(1);
        //      //                string name = reader.GetString(2);
        //      //                string otch = reader.GetString(3);
        //      //                string phone = reader.GetString(4);
        //      //                User.UserTypes type = User.UserTypes.VOSP;

        //      //                if (reader.GetInt32(5) == 2)
        //      //                {
        //      //                    type = User.UserTypes.MET;
        //      //                }
        //      //                reader.Close();
        //      //                currentUser = new User(id, type, login, name, fam, otch, phone);
        //      //                if (currentUser.UserType == User.UserTypes.VOSP)
        //      //                {
        //      //                    getChildrenInGroup();
        //      //                }
        //      //                return AuthResult.AUTH_PASS;
        //      //            }
        //      //            else
        //      //            {
        //      //                return AuthResult.AUTH_FAIL;
        //      //            }
        //      //        }

        //      //}
        //      //catch (MySqlException ex)
        //      //{
        //      //    System.Windows.Forms.MessageBox.Show(ex.ToString());
        //      //    return AuthResult.EXCEPTION;
        //      //}

        //  }

        //static public bool ChangeCurrentUser(string fam, string name, string otch, string phone, string password = null)
        //{

        //    if (password == null)
        //    {
        //        command.CommandText = String.Format(@"update users set fam = '{0}',
        //                                                                    name='{1}',
        //                                                                    otch='{2}', 
        //                                                                    phone = '{3}' 
        //                                                  where  user_id = '{4}'", fam, name, otch, phone, currentUser.Id);

        //    }
        //    else
        //    {

        //        command.CommandText = String.Format(@"update users set fam = '{0}',
        //                                                                    name='{1}',
        //                                                                    otch='{2}', 
        //                                                                    phone = '{3}' ,
        //                                                                    password = '{4}'
        //                                                  where  user_id = '{5}'", fam, name, otch, phone, User.getHash(password), currentUser.Id);
        //    }

        //    try
        //    {
        //        command.ExecuteNonQuery();
        //        //currentUser = new User(currentUser.Id, currentUser.UserType, currentUser.Login, name, fam, otch, phone);
        //        return true;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.ToString());
        //        return false;
        //    }


        //}


        //static public string getChildrenInGroup()
        //{

        //    try
        //    {
        //        command.CommandText = String.Format(" select id_group from tangram.groups where id_user = '{0}'", currentUser.Id);
        //        Object res = command.ExecuteScalar();

        //        string groupId = "";
        //        if (res == null)
        //        {
        //            return "Воспитатель не зарегистрирован ни в одной из групп ";
        //        }
        //        else
        //        {
        //            groupId = res.ToString();
        //        }

        //        command.CommandText = String.Format(" select id_child, concat(name, ' ', fam) as 'childName', subGroup from childs where id_group = '{0}' order by fam ", groupId);
        //        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
        //        {
        //            command.ExecuteNonQuery();
        //            children.Clear();
        //            adapter.Fill(children);
        //        }
        //        command.CommandText = String.Format(" select max(subGroup) from childs where id_group = '{0}'", groupId);
        //        subGroupCount = Convert.ToInt32(command.ExecuteScalar());

        //        return "";
        //    }
        //    catch (MySqlException ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.ToString());
        //        return "Ошибка базы данных №" +ex.Number;
        //    }
        //}


        //static public string BeginClass()
        //{
        //    try
        //    {
        //        command.CommandText = String.Format("select id_class from tangram.classes where  id_user = '{0}' and class_date = '{1}'", currentUser.Id, DateTime.Now.ToString("yyyy-MM-dd"));
        //        Object res = command.ExecuteScalar();
        //        if (res == null)
        //        {
        //            command.CommandText = String.Format("insert into tangram.classes (id_user, class_date) values ('{0}','{1}')", currentUser.Id, DateTime.Now.ToString("yyyy-MM-dd"));
        //            command.ExecuteNonQuery();
        //            command.CommandText = "select last_insert_id();";
        //            classId = command.ExecuteScalar().ToString();
        //        }
        //        else
        //        {
        //            classId = res.ToString();
        //        }
        //        return "";
        //    }
        //    catch (MySqlException ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.ToString());
        //        return "Ошибка базы данных №" + ex.Number;
        //    }

        //}


        //public static void getStatisticsForGroup(int groupId)
        //{
        //    command.CommandText = String.Format("select id_child, concat(name, ' ', fam) as 'childName', subGroup from childs where id_group = '{0}' order by fam ", groupId);

        //    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
        //    {
        //        command.ExecuteNonQuery();
        //        statistics.Clear();
        //        adapter.Fill(statistics);
        //    }

        //    command.CommandText = String.Format(" select id_user from tangram.groups where id_group = '{0}'", groupId);
        //    Object res = command.ExecuteScalar();

        //    string userId = res.ToString();

        //    command.CommandText = String.Format(" select count(*) from tangram.classes where id_user = '{0}'", userId);
        //    string totalCLassCount = command.ExecuteScalar().ToString();




        //    statistics.Columns.Add("study_count");
        //    statistics.Columns["study_count"].DataType = typeof(string);
        //    statistics.Columns.Add("difficulty2_score");
        //    statistics.Columns["difficulty2_score"].DataType = typeof(string);
        //    statistics.Columns.Add("difficulty1_score");
        //    statistics.Columns["difficulty1_score"].DataType = typeof(string);

        //    for(int i = 0; i<statistics.Rows.Count; i++)
        //    {
        //        command.CommandText = String.Format(" select count(*) from tangram.results where id_child = '{0}'", statistics.Rows[i]["id_child"].ToString());
        //        string classCount = command.ExecuteScalar().ToString();

        //        command.CommandText = String.Format(" select avg(result) from tangram.results where id_child = '{0}' and id_level = '1' ", statistics.Rows[i]["id_child"].ToString());
        //        Object diff1Res = command.ExecuteScalar();
        //        if (diff1Res==null)
        //        {
        //            statistics.Rows[i]["difficulty1_score"] = "-";
        //        }
        //        else
        //        {
        //            double diff1 = Convert.ToDouble(diff1Res);
        //            statistics.Rows[i]["difficulty1_score"] = Math.Round(diff1, 2).ToString();
        //        }


        //        command.CommandText = String.Format("select  ", groupId);

        //    }




        //}



        //static public void EndClass()
        //{
        //    childrenInClass.Dispose();

        //}

    }
}

