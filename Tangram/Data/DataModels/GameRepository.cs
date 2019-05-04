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
            resultInfo.TableName = "results";
            resultInfo.IdName = "id_result";
            resultInfo.parameters.Add(new MySqlParameter("id_result", MySqlDbType.Int32));
            resultInfo.parameters.Add(new MySqlParameter("id_child", MySqlDbType.Int32));
            resultInfo.parameters.Add(new MySqlParameter("score", MySqlDbType.Int32));
            resultInfo.parameters.Add(new MySqlParameter("id_figure", MySqlDbType.Int32));
            resultInfo.parameters.Add(new MySqlParameter("id_level", MySqlDbType.Int32));
            resultInfo.parameters.Add(new MySqlParameter("id_class", MySqlDbType.Int32));
            resultInfo.parameters.Add(new MySqlParameter("id_group_h", MySqlDbType.Int32));

            resultInfo.GenerateStatements();

            InitCommandParameters();

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
            parameters["id_level"].Value = ((int)c.DifficultyType)+1;
            parameters["id_group_h"].Value = c.GroupId;
            parameters["id_class"].Value = c.ClassId;
            parameters["score"].Value = c.Score;
        }
    }
}
