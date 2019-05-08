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
    public class ChildJournalRepository : Repository<Child_Journal>
    {
        private TableInfo tableInfo;

        protected override TableInfo info => tableInfo;

        public ChildJournalRepository(MySqlConnection connection) : base(connection, true)
        {
            tableInfo  = new TableInfo();

            tableInfo.parameters.Add(new MySqlParameter("id_journal", MySqlDbType.Int32));
            tableInfo.parameters.Add(new MySqlParameter("id_child", MySqlDbType.Int32));
            tableInfo.parameters.Add(new MySqlParameter("id_group_h", MySqlDbType.Int32));
            tableInfo.parameters.Add(new MySqlParameter("subGroup", MySqlDbType.Int32));

            tableInfo.TableName = "child_journal";
            tableInfo.IdName = "id_journal";
            tableInfo.SelectStatement = "select * from child_journal";
            tableInfo.GenerateStatements();
            InitCommandParameters();
            AutoUpload = false;
            Upload();
        }

        protected override Child_Journal MapOut(DataRow row)
        {
            Child_Journal journal = new Child_Journal();
            journal.Id = Convert.ToInt32(row["id_journal"]);
            journal.SubGroup = Convert.ToInt32(row["subGroup"]);
            journal.ChildId = Convert.ToInt32(row["id_child"]);
            journal.GroupHistoryId = Convert.ToInt32(row["id_group_h"]);
            return journal;
        }

        protected override void SetCommandParameters(Child_Journal c, MySqlParameterCollection parameters)
        {
            parameters["id_journal"].Value = c.Id;
            parameters["id_child"].Value = c.ChildId;
            parameters["id_group_h"].Value = c.GroupHistoryId;
            parameters["subGroup"].Value = c.SubGroup;
        }
    }
}
