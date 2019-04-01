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
    class ChildrenRepository : Repository<Child>
    {
        public int currentGroupCount { get { return 2; } }


        public ChildrenRepository(MySqlConnection connection) : base(connection, TableInfoHolder.getInfo("childs"))
        {
            Upload();
        }

        public void GetChildrenInGroup(int groupId)
        {
            filteredTable.RowFilter = "id_group= " + groupId;
            //int count = 0;`````````````````````````````````````````
            //foreach(DataRow row in Table.Rows)
            //{
            //    if(row["\subGroup"])
            //}
        }

        public bool Update(Child child)
        {
            return base.Update(child.Id, child);
        }

        protected override Child MapOut(DataRow row)
        {
            Child child = new Child()
            {
                Id = Convert.ToInt32(row["id_child"]),
                Fam = row["fam"].ToString(),
                Name = row["name"].ToString(),
                gender = Convert.ToInt32(row["gender"]) > 0,
                GroupId = Convert.ToInt32(row["id_group"]),
                SubGroup = Convert.ToInt32(row["subGroup"])

            };
            return child;
        }

        protected override void SetCommandParameters(Child c, MySqlParameterCollection parameters)
        {
            parameters["id_child"].Value = c.Id;
            parameters["fam"].Value = c.Fam;
            parameters["name"].Value = c.Name;
            parameters["gender"].Value = Convert.ToInt32(c.gender);
            parameters["id_group"].Value = c.GroupId;
            parameters["subGroup"].Value = c.SubGroup;
        }
    }
}
