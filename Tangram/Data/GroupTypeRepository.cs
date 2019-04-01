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
        public GroupTypeRepository(MySqlConnection connection) : base(connection, TableInfoHolder.getInfo("group_type"))
        {
            RepeatErrorMsg = "Тип группы не должен повторяться!";
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

        public bool Update(Group_types group_type)
        {
            return base.Update(group_type.Id, group_type);
        }
    }
}
