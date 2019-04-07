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
    class FigureRepository : Repository<Figure>
    {
        private TableInfo figureInfo;

        protected override TableInfo info => figureInfo;

        public FigureRepository(MySqlConnection connection) : base(connection, true)
        {
            figureInfo = new TableInfo();
            figureInfo.TableName = "figures";
            figureInfo.IdName = "id_figure";
            figureInfo.parameters.Add(new MySqlParameter("id_figure", MySqlDbType.Int32));
            figureInfo.parameters.Add(new MySqlParameter("figure_name", MySqlDbType.VarChar));
            figureInfo.parameters.Add(new MySqlParameter("figure_data", MySqlDbType.JSON));
            figureInfo.parameters.Add(new MySqlParameter("id_group", MySqlDbType.Int32));
            figureInfo.parameters.Add(new MySqlParameter("id_user", MySqlDbType.Int32));

            figureInfo.SelectStatement = "select id_figure, figure_name, id_group, id_user from figures";
            figureInfo.GenerateStatements();
            figureInfo.linkedTables.Add("results");
            InitCommandParameters();
            Upload();
        }

        protected override Figure MapOut(DataRow row)
        {
            Figure figure = new Figure();
            figure.Id = Convert.ToInt32(row["id_figure"]);
            figure.FigureName = row["figure_name"].ToString();
            figure.Group_id = Convert.ToInt32(row["id_group"]);
            figure.User_id = Convert.ToInt32(row["id_user"]);
            byte[] figure_data = Encoding.UTF8.GetBytes(row["figure_data"].ToString());
            figure.TangramElement = GraphicsElements.TangramElement.Deserialize(figure_data);
            return figure;
        }

        protected override void SetCommandParameters(Figure c, MySqlParameterCollection parameters)
        {
            parameters["id_figure"].Value = c.Id;
            parameters["figure_name"].Value = c.FigureName;
            parameters["id_group"].Value = c.Group_id;
            parameters["id_user"].Value = c.User_id;
            parameters["figure_data"].Value = GraphicsElements.TangramElement.Serialize(c.TangramElement);
        }
    }
}
