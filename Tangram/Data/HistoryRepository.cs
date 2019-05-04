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
    public class HistoryRepository : Repository<History_group>
    {
        protected override TableInfo info => historyInfo;
        private TableInfo historyInfo;

        public HistoryRepository(MySqlConnection connection) : base(connection, false)
        {
            historyInfo = new TableInfo();
            historyInfo.parameters.Add(new MySqlParameter("id_group_h", MySqlDbType.Int32));
            historyInfo.parameters.Add(new MySqlParameter("id_group", MySqlDbType.Int32));
            historyInfo.parameters.Add(new MySqlParameter("id_user", MySqlDbType.Int32));
            historyInfo.parameters.Add(new MySqlParameter("history_year", MySqlDbType.Int32));

            historyInfo.TableName = "group_history";
            historyInfo.IdName = "id_group_h";

            historyInfo.linkedTables.Add("results");
            historyInfo.linkedTables.Add("child_journal");
            //historyInfo.linkedTables.Add("childs");

            historyInfo.GenerateStatements();
            InitCommandParameters();
            AutoUpload = false;
        }

        

        protected override History_group MapOut(DataRow row)
        {
            return new History_group() {
                Id = Convert.ToInt32(row["id_group_h"]),
                GroupId = Convert.ToInt32(row["id_group"]),
                UserId = Convert.ToInt32(row["id_user"]),
                Year = Convert.ToInt32(row["history_year"])
            };

        }

        protected override void SetCommandParameters(History_group c, MySqlParameterCollection parameters)
        {
            parameters["id_group_h"].Value = c.Id;
            parameters["id_group"].Value = c.GroupId;
            parameters["id_user"].Value = c.UserId;
            parameters["history_year"].Value = c.Year;
        }
    }
}
