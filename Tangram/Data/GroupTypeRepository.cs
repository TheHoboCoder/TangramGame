using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangram.Data.DataModels;

namespace Tangram.Data
{
    class GroupTypeRepository : Repository<Group_types>
    {
        private TableInfo group_types;
        protected override TableInfo info => group_types;

        public GroupTypeRepository(MySqlConnection connection) : base(connection, false)
        {
            RepeatErrorMsg = "Тип группы не должен повторяться!";

            group_types = new TableInfo();
            group_types.parameters.Add(new MySqlParameter("group_type_id", MySqlDbType.Int32));
            group_types.parameters.Add(new MySqlParameter("group_type_name", MySqlDbType.VarChar));
            group_types.TableName = "group_type";
            group_types.IdName = "group_type_id";

            group_types.linkedTables.Add("garden_groups");

            group_types.SelectStatement = "select group_type_id,group_type_name from group_type";
            group_types.GenerateStatements();
            InitCommandParameters();
            Upload();
        }


        protected override Group_types MapOut(DataRow row)
        {
            Group_types group = new Group_types()
            {
                Id = Convert.ToInt32(row["group_type_id"]),
                Group_type_name = row["group_type_name"].ToString()
            };
            return group;
        }

        protected override void SetCommandParameters(Group_types c, MySqlParameterCollection parameters)
        {
            parameters["group_type_name"].Value = c.Group_type_name;
            parameters["group_type_id"].Value = c.Id;
        }

      
    }
}
