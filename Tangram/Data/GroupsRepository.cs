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
    class GroupsRepository : Repository<Garden_groups>
    {
        private TableInfo groupInfo;

        protected override TableInfo info => groupInfo;

        public GroupsRepository(MySqlConnection connection) : base(connection, false)
        {
            groupInfo = new TableInfo();
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
            InitCommandParameters();
            Upload();
        }

        public GroupsRepository(MySqlConnection connection, int userId) : base(connection, true)
        {
            groupInfo = new TableInfo();
            groupInfo.TableName = "garden_groups";
            groupInfo.IdName = "id_group";
            groupInfo.SelectStatement = "select garden_groups.id_group, garden_groups.group_name, group_type.group_type_name,  garden_groups.group_type_id, garden_groups.count, garden_groups.id_user," +
                                               "concat(users.fam, ' ', ucase(left(users.name, 1)), '.', ucase(left(users.otch, 1))) as 'usersInitials' from garden_groups " +
                                               "inner join users on garden_groups.id_user = users.id_user " +
                                               " inner join group_type on garden_groups.group_type_id = group_type.group_type_id";



            //groupInfo.GenerateStatements();
            groupInfo.linkedTables.Add("childs");
            Upload(String.Format("garden_groups.id_user= '{0}'", userId));
        }

        //public Garden_groups GetGroupByTeacherId(int userId)
        //{
        //        Table.Select(String.Format("id_user= '{0}'", id));
        //        return MapOut(Table.Rows[0]);
        //}

        public void FilterGroupsByType(int groupTypeId)
        {
            filteredTable.RowFilter = "group_type_id= " + groupTypeId;
        }

        protected override Garden_groups MapOut(DataRow row)
        {
            Garden_groups groups = new Garden_groups()
            {
                Id = Convert.ToInt32(row["id_group"]),
                Group_Name = row["group_name"].ToString(),
                GroupTypeId = Convert.ToInt32(row["group_type_id"]),
                childCount = Convert.ToInt32(row["count"]),
                TeacherId = Convert.ToInt32(row["id_user"])
            };
            return groups;
        }

        protected override void SetCommandParameters(Garden_groups c, MySqlParameterCollection parameters)
        {
            parameters["id_group"].Value = c.Id;
            parameters["group_name"].Value = c.Group_Name;
            parameters["group_type_id"].Value = c.GroupTypeId;
            parameters["count"].Value = c.childCount;
            parameters["id_user"].Value = c.TeacherId;
        }
    }
}
