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

        public UserRepository(MySqlConnection connection) : base(connection, TableInfoHolder.getInfo("users"))
        {
            RepeatErrorMsg = "Логин не должен повторяться!";

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


        public bool Update(User user)
        {
            if(base.Update(user.Id, user))
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
            parameters["password"].Value =user.Password;

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
