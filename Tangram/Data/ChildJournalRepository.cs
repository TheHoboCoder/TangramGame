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

        public ChildJournalRepository(MySqlConnection connection) : base(connection, false)
        {
            tableInfo  = new TableInfo();

            tableInfo.parameters.Add(new MySqlParameter("id_journal", MySqlDbType.Int32));
            tableInfo.parameters.Add(new MySqlParameter("id_child", MySqlDbType.Int32));
            tableInfo.parameters.Add(new MySqlParameter("id_group_h", MySqlDbType.Int32));
            tableInfo.parameters.Add(new MySqlParameter("subGroup", MySqlDbType.Int32));

            tableInfo.TableName = "child_journal";
            tableInfo.IdName = "id_journal";

            tableInfo.GenerateStatements();
            InitCommandParameters();
            AutoUpload = false;
        }

       
        protected override Child_Journal MapOut(DataRow row)
        {
            throw new NotImplementedException();
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
