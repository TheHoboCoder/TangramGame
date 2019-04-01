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
        public GroupsRepository(MySqlConnection connection) : base(connection, TableInfoHolder.getInfo("garden_groups"))
        {
            Upload();
        }


        public bool Update(Garden_groups groups)
        {
            return base.Update(groups.Id, groups);
        }


        public Garden_groups GetGroupByTeacherId(int id)
        {
                Table.Select(String.Format("id_user= '{0}'", id));
                return MapOut(Table.Rows[0]);
        }

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
