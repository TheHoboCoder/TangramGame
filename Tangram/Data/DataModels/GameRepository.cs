using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Tangram.Data.DataModels
{
    class GameRepository : Repository<Result>
    {
        private TableInfo resultInfo;
        protected override TableInfo info => resultInfo;

        public GameRepository(MySqlConnection connection) : base(connection, true)
        {

            resultInfo = new TableInfo();

            resultInfo.parameters.Add(new MySqlParameter("id_result", MySqlDbType.Int32));
            resultInfo.parameters.Add(new MySqlParameter("id_child", MySqlDbType.Int32));
            resultInfo.parameters.Add(new MySqlParameter("score", MySqlDbType.Int32));
            resultInfo.parameters.Add(new MySqlParameter("id_figure", MySqlDbType.Int32));
            resultInfo.parameters.Add(new MySqlParameter("id_level", MySqlDbType.Int32));
            resultInfo.parameters.Add(new MySqlParameter("id_group", MySqlDbType.Int32));

            resultInfo.GenerateStatements();

        }

        

        protected override Result MapOut(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override void SetCommandParameters(Result c, MySqlParameterCollection parameters)
        {
            parameters["id_result"].Value = c.Id;
            parameters["id_child"].Value = c.ChildId;
            parameters["id_figure"].Value = c.FigureId;
            parameters["id_level"].Value = c.DifficultyType;
            parameters["id_group"].Value = c.GroupId;
            parameters["score"].Value = c.Score;

        }
    }
}
