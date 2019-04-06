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

        private TableInfo childInfo;

        protected override TableInfo info => childInfo;

        public ChildrenRepository(MySqlConnection connection) : base(connection,false)
        {
          
            childInfo = new TableInfo();

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
            InitCommandParameters();
            Upload();
        }

        public ChildrenRepository(MySqlConnection connection, int groupId) : base(connection, true)
        {
            childInfo = new TableInfo();
            childInfo.SelectStatement = "SELECT  childs.id_child, childs.id_group, childs.subGroup, childs.name, childs.fam, childs.gender,concat(childs.name, ' ', childs.fam) as 'childName'," +
                                                "concat(childs.subGroup, ' подгруппа') as subGroupName, if (gender,'Мужской','Женский') as 'genderText'" +
                                               "from childs " +
                                                "inner join garden_groups on childs.id_group = garden_groups.id_group";
            Upload("childs.id_group = '" + groupId + "'");
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
