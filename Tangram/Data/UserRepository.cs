using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Tangram.Data.DataModels;

namespace Tangram.Data
{
    class UserRepository : Repository<User>
    {

        public User currentUser { get; private set; }

        private TableInfo usersInfo;
        protected override TableInfo info => usersInfo;

        public UserRepository(MySqlConnection connection) : base(connection, false)
        {
            RepeatErrorMsg = "Логин не должен повторяться!";

            usersInfo = new TableInfo();

            usersInfo.parameters.Add(new MySqlParameter("id_user", MySqlDbType.Int32));
            usersInfo.parameters.Add(new MySqlParameter("login", MySqlDbType.VarChar));
            usersInfo.parameters.Add(new MySqlParameter("password", MySqlDbType.VarChar));
            usersInfo.parameters.Add(new MySqlParameter("fam", MySqlDbType.VarChar));
            usersInfo.parameters.Add(new MySqlParameter("name", MySqlDbType.VarChar));
            usersInfo.parameters.Add(new MySqlParameter("otch", MySqlDbType.VarChar));
            usersInfo.parameters.Add(new MySqlParameter("phone", MySqlDbType.VarChar));
            usersInfo.parameters.Add(new MySqlParameter("role_id", MySqlDbType.Int32));

            usersInfo.TableName = "users";
            usersInfo.IdName = "id_user";
            usersInfo.SelectStatement = @"select users.id_user, users.login, users.fam,users.password, users.name, users.otch, users.phone,user_roles.role_name, user_roles.role_id,
                                          concat(users.fam, ' ', ucase(left(users.name, 1)), '.', ucase(left(users.otch, 1))) as 'usersInitials'
                                          from users
                                          inner join user_roles on users.role_id = user_roles.role_id";
            usersInfo.GenerateStatements();

            usersInfo.linkedTables.Add("classes");
            usersInfo.linkedTables.Add("figures");
            usersInfo.linkedTables.Add("garden_groups");
            InitCommandParameters();

        }



        public enum AuthResult
        {
            AUTH_FAIL,
            AUTH_PASS,
            EXCEPTION
        }

        public AuthResult Auth(string login, string password)
        {
            string hash = User.getHash(password);
            //string hash =password;


            if (!Upload(String.Format("login = '{0}' and password='{1}'", login, hash))) {
                return AuthResult.EXCEPTION;
            }

            if (Table.Rows.Count == 0)
            {
                return AuthResult.AUTH_FAIL;
            }
            else
            {
                currentUser = MapOut(Table.Rows[0]) as User;
                Database.Init(currentUser);
                if(currentUser.UserType == User.UserTypes.MET)
                {
                    Upload(" id_user <> '"+currentUser.Id+"'");
                }
                return AuthResult.AUTH_PASS;
            }
        }


       


        public User getUserByGroupId(int id)
        {
            Table.Select(String.Format("id_group = '{0}'", id));
            return MapOut(Table.Rows[0]);
        }

        public void FilterUsersByType(User.UserTypes type)
        {
            filteredTable.RowFilter = "role_id = " + (type == User.UserTypes.MET ? 2 : 1).ToString();
        }


        public void FilterUsersByFam(string fam)
        {
            filteredTable.RowFilter = String.Format("fam  like '{0}%'", fam);
        }


        public new bool Update(User user)
        {
            if(base.Update( user))
            {
                if (user.Id == currentUser.Id)
                {
                    currentUser = user;
                }
                return true;
            }
            else
            {
                return false;
            }
        }



        protected override User MapOut(DataRow row)
        {
            return new User(Convert.ToInt32(row["id_user"]),
                                 Convert.ToInt32(row["role_id"]) == 2 ? User.UserTypes.MET : User.UserTypes.VOSP,
                                 row["login"].ToString(),
                                 row["name"].ToString(),
                                 row["fam"].ToString(),
                                 row["otch"].ToString(),
                                 row["phone"].ToString(),
                                 row["password"].ToString()
                );


        }

        protected override void SetCommandParameters(User user, MySqlParameterCollection parameters)
        {
            parameters["id_user"].Value = user.Id;
            parameters["login"].Value = user.Login;
            parameters["fam"].Value = user.Fam;
            parameters["name"].Value = user.Name;
            parameters["otch"].Value = user.Otch;
            parameters["phone"].Value = user.Phone;
            parameters["password"].Value =User.getHash(user.Password);

            if(user.UserType == User.UserTypes.MET)
            {
                parameters["role_id"].Value = 2;
            }
            else
            {
                parameters["role_id"].Value = 1;
            }
           
        }
    }
}
