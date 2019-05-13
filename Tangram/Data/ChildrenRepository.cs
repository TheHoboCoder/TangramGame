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
    public class ChildrenRepository : Repository<Child>
    {
        public int currentGroupCount { get { return 2; } }

        private TableInfo childInfo;

        protected override TableInfo info => childInfo;

        public ChildrenRepository(MySqlConnection connection) : base(connection,false)
        {
          
            childInfo = new TableInfo();

            childInfo.parameters.Add(new MySqlParameter("id_child", MySqlDbType.Int32));
            //childInfo.parameters.Add(new MySqlParameter("id_group", MySqlDbType.Int32));
            childInfo.parameters.Add(new MySqlParameter("fam", MySqlDbType.VarChar));
            childInfo.parameters.Add(new MySqlParameter("name", MySqlDbType.VarChar));
            //childInfo.parameters.Add(new MySqlParameter("subGroup", MySqlDbType.VarChar));
            childInfo.parameters.Add(new MySqlParameter("gender", MySqlDbType.Int32));
            childInfo.parameters.Add(new MySqlParameter("birthday", MySqlDbType.DateTime));

            childInfo.TableName = "childs";
            childInfo.IdName = "id_child";


            childInfo.SelectStatement = @"SELECT  childs.id_child, child_journal.id_journal, child_journal.id_group_h,  childs.name, childs.fam, childs.gender,concat(childs.name, ' ', childs.fam) as 'childName',
                                                  concat(child_journal.subGroup, ' подгруппа') as subGroupName, 
                                                  child_journal.subGroup,
                                                  group_history.id_group,
                                                  if (gender,'Мужской','Женский') as 'genderText',
                                                  timestampdiff(year, childs.birthday, CURDATE()) as 'age',
                                                  childs.birthday
                                         from childs
                                         inner join child_journal on child_journal.id_child = childs.id_child
                                         inner join group_history on child_journal.id_group_h = group_history.id_group_h";
            childInfo.linkedTables.Add("results","Результаты");
            childInfo.GenerateStatements();
            InitCommandParameters();
            AutoUpload = false;
            Upload();
        }

        public void GetData()
        {
            Upload();
        }

        public ChildrenRepository(MySqlConnection connection, int groupId) : base(connection, true)
        {
            childInfo = new TableInfo();
            childInfo.SelectStatement = @"SELECT  childs.id_child, child_journal.id_journal, child_journal.id_group_h,  childs.name, childs.fam, childs.gender,concat(childs.name, ' ', childs.fam) as 'childName',
                                                  concat(child_journal.subGroup, ' подгруппа') as subGroupName, 
                                                  if (gender,'Мужской','Женский') as 'genderText',
                                                  child_journal.subGroup,
                                                  group_history.id_group,
                                                  timestampdiff(year, childs.birthday, CURDATE()) as 'age',
                                                  childs.birthday
                                         from childs
                                         inner join child_journal on child_journal.id_child = childs.id_child
                                         inner join group_history on child_journal.id_group_h = group_history.id_group_h";
            Upload("child_journal.id_group_h = '" + groupId + "'");
        }


        public void GetChildrenInGroup(int groupId)
        {
            filteredTable.RowFilter = "id_group_h= " + groupId;
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
                birthday = Convert.ToDateTime(row["birthday"]),
                //GroupId = Convert.ToInt32(row["id_group"]),
                SubGroup = Convert.ToInt32(row["subGroup"])

            };
            return child;
        }

        protected override void SetCommandParameters(Child c, MySqlParameterCollection parameters)
        {
            parameters["id_child"].Value = c.Id;
            parameters["fam"].Value = c.Fam;
            parameters["name"].Value = c.Name;
            parameters["birthday"].Value = c.birthday.ToString("yyyy-MM-dd");
            parameters["gender"].Value = Convert.ToInt32(c.gender);
            //parameters["id_group"].Value = c.GroupId;
            //parameters["subGroup"].Value = c.SubGroup;
        }
    }
}
