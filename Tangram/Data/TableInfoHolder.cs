using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.Data.DataModels
{
    class TableInfoHolder
    {
        private static Dictionary<string, TableInfo> dbInfo = new Dictionary<string, TableInfo>();

        public static TableInfo getInfo(string table)
        {
            return dbInfo[table];
        }
        public static void Init()
        {

            #region Table Users
            TableInfo usersInfo = new TableInfo();

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

            dbInfo.Add("users", usersInfo);
            #endregion 

            #region Table Group_type
            TableInfo group_types = new TableInfo();
            group_types.parameters.Add(new MySqlParameter("group_type_id", MySqlDbType.Int32));
            group_types.parameters.Add(new MySqlParameter("group_type_name", MySqlDbType.VarChar));
            group_types.TableName = "group_type";
            group_types.IdName = "group_type_id";

            group_types.linkedTables.Add("garden_groups");

            group_types.SelectStatement = "select group_type_id,group_type_name from group_type";
            group_types.GenerateStatements();
            dbInfo.Add("group_type", group_types);
            #endregion

            #region Table Garden_groups
            TableInfo groupInfo = new TableInfo();
            groupInfo.parameters.Add(new MySqlParameter("id_group", MySqlDbType.Int32));
            groupInfo.parameters.Add(new MySqlParameter("group_name", MySqlDbType.VarChar));
            groupInfo.parameters.Add(new MySqlParameter("group_type_id", MySqlDbType.Int32));
            groupInfo.parameters.Add(new MySqlParameter("count", MySqlDbType.Int32));
            groupInfo.parameters.Add(new MySqlParameter("id_user", MySqlDbType.Int32));

            groupInfo.TableName = "garden_groups";
            groupInfo.IdName = "id_group";
            groupInfo.SelectStatement = "select garden_groups.id_group, garden_groups.group_name, group_type.group_type_name,  garden_groups.group_type_id, garden_groups.count, garden_groups.id_user," +
                                               "concat(users.fam, ' ', ucase(left(users.name, 1)), '.', ucase(left(users.otch, 1))) as 'usersInitials' from garden_groups " +
                                               "inner join users on garden_groups.id_user = users.id_user " +
                                               " inner join group_type on garden_groups.group_type_id = group_type.group_type_id";



            groupInfo.GenerateStatements();
            groupInfo.linkedTables.Add("childs");

            dbInfo.Add("garden_groups", groupInfo);
            #endregion

            #region Table Childs
            TableInfo childInfo = new TableInfo();

            childInfo.parameters.Add(new MySqlParameter("id_child", MySqlDbType.Int32));
            childInfo.parameters.Add(new MySqlParameter("id_group", MySqlDbType.Int32));
            childInfo.parameters.Add(new MySqlParameter("fam", MySqlDbType.VarChar));
            childInfo.parameters.Add(new MySqlParameter("name", MySqlDbType.VarChar));
            childInfo.parameters.Add(new MySqlParameter("subGroup", MySqlDbType.VarChar));
            childInfo.parameters.Add(new MySqlParameter("gender", MySqlDbType.Int32));

            childInfo.TableName = "childs";
            childInfo.IdName = "id_child";

            childInfo.SelectStatement = "SELECT  childs.id_child, childs.id_group, childs.subGroup, childs.name, childs.fam, childs.gender,concat(childs.name, ' ', childs.fam) as 'childName'," +
                                                 "concat(childs.subGroup, ' подгруппа') as subGroupName, if (gender,'Мужской','Женский') as 'genderText'" +
                                                "from childs " +
                                                 "inner join garden_groups on childs.id_group = garden_groups.id_group";
            childInfo.linkedTables.Add("results");
            childInfo.GenerateStatements();

            dbInfo.Add("childs", childInfo);
            #endregion 



        }

        public static string getSelectStatement(string table)
        {
            return dbInfo[table].SelectStatement;
        }

        public static string getUpdateStatement(string table)
        {
            return dbInfo[table].UpdateStatement;
        }

        public static string getInsertStatement(string table)
        {
            return dbInfo[table].InsertStatement;
        }

        public static string getId(string table)
        {
            return dbInfo[table].IdName;
        }

        public static string[] getLinkedTables(string table)
        {
            return dbInfo[table].linkedTables.ToArray();
        }


    }
}
