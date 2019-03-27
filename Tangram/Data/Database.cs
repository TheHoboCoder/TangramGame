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



        static public User currentUser;
        static private string classId = "";

        static public DataTable users;

        static public int subGroupCount = 0;
        static public DataTable groups;
        static public DataTable children;
        static public DataTable figures;


        static public  bool Open()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
            
        }

      public enum AuthResult{
            AUTH_FAIL,
            AUTH_PASS,
            EXCEPTION
        }

       static public AuthResult Auth(string login, string password)
        {
            string hash = User.getHash(password);
            try
            {

                    command.CommandText = String.Format("select user_id,fam,name, otch,phone, role_id from users where login = '{0}' and password='{1}'", login, hash);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int id = reader.GetInt32(0);
                            string fam = reader.GetString(1);
                            string name = reader.GetString(2);
                            string otch = reader.GetString(3);
                            string phone = reader.GetString(4);
                            User.UserTypes type = User.UserTypes.VOSP;

                            if (reader.GetInt32(5) == 2)
                            {
                                type = User.UserTypes.MET;
                            }

                            currentUser = new User(id, type, login, name, fam, otch, phone);
                            return AuthResult.AUTH_PASS;
                        }
                        else
                        {
                            return AuthResult.AUTH_FAIL;
                        }
                    }

            }
            catch (MySqlException)
            {
                return AuthResult.EXCEPTION;
            }

        }

        static public bool ChangeCurrentUser(string fam, string name, string otch, string phone, string password = null)
        {

                command.Connection = connection;
                if (password == null)
                {
                    command.CommandText = String.Format(@"update users set fam = '{0}',
                                                                            name='{1}',
                                                                            otch='{2}', 
                                                                            phone = '{3}' 
                                                          where  user_id = '{4}''", fam, name, otch,phone, currentUser.Id);

                }
                else
                {

                    command.CommandText = String.Format(@"update users set fam = '{0}',
                                                                            name='{1}',
                                                                            otch='{2}', 
                                                                            phone = '{3}' ,
                                                                            password = '{4}'
                                                          where  user_id = '{4}''", fam, name, otch, phone,User.getHash(password), currentUser.Id);
                }

                try
                {
                    command.ExecuteNonQuery();
                    currentUser = new User(currentUser.Id, currentUser.UserType, currentUser.Login, name, fam, otch, phone);
                    return true;
                }
                catch (MySqlException)
                {
                    return false;
                }

            
        }


        static public string getChildrenInGroup()
        {
            command.CommandText = String.Format(" select id_group from groups where id_user = {0}", currentUser.Id);
            Object res = command.ExecuteScalar();

            string groupId = "";
            if (res == null)
            {
                return "Воспитатель не зарегистрирован ни в одной из групп ";
            }
            else
            {
                groupId = res.ToString();
            }

            command.CommandText = String.Format(" select name, fam from childs where id_group = '{0}'", groupId);
            try
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    command.ExecuteNonQuery();
                    children.Clear();
                    adapter.Fill(children);
                }
                command.CommandText = String.Format(" select max(subGroup) from childs where id_group = '{0}'", groupId);
                subGroupCount = Convert.ToInt32(command.ExecuteScalar());

                return "";
            }
            catch (MySqlException ex)
            {
                return "Ошибка базы данных №" +ex.Number;
            }
        }


        static public string BeginClass()
        {
            try
            {
                command.CommandText = String.Format("select id_class from classes where  id_user = {0} and class_date = '{1}')", currentUser.Id, DateTime.Now.ToString("yyyy-MM-dd"));
                Object res = command.ExecuteScalar();
                if (res == null)
                {
                    command.CommandText = String.Format("insert into classes (id_user, class_date) values ({0},'{1}')", currentUser.Id, DateTime.Now.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                    command.CommandText = "select last_insert_id();";
                    classId = command.ExecuteScalar().ToString();
                }
                else
                {
                    classId = res.ToString();
                }
                return "";
            }
            catch (MySqlException ex)
            {
                return "Ошибка базы данных №" + ex.Number;
            }
           
        }

    }
}

