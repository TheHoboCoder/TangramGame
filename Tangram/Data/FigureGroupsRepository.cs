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
    class FigureGroupsRepository : Repository<FigureGroup>
    {
        protected TableInfo figure_groups;

        protected override TableInfo info => figure_groups;

        public FigureGroupsRepository(MySqlConnection connection) : base(connection,true)
        {
            figure_groups = new TableInfo();

            figure_groups.TableName = "figure_groups";
            figure_groups.IdName = "id_group";
            figure_groups.parameters.Add(new MySqlParameter("id_group", MySqlDbType.Int32));
            figure_groups.parameters.Add(new MySqlParameter("group_name", MySqlDbType.VarChar));
            figure_groups.parameters.Add(new MySqlParameter("group_description", MySqlDbType.VarChar));

            figure_groups.SelectStatement = "select id_group, group_name, group_description from figure_groups";
            figure_groups.GenerateStatements();
            figure_groups.linkedTables.Add("figures");
            InitCommandParameters();
            Upload();

            RepeatErrorMsg = "Такая группа уже есть.";

        }


        protected override string linkedErrorMsg(string table)
        {
            return base.linkedErrorMsg(table);
        }

        protected override FigureGroup MapOut(DataRow row)
        {
            FigureGroup group = new FigureGroup();
            group.Id = Convert.ToInt32(row["id_group"]);
            group.Name = row["group_name"].ToString();
            group.Comment = row["group_description"].ToString();
            return group;

        }

        protected override void SetCommandParameters(FigureGroup c, MySqlParameterCollection parameters)
        {
            parameters["id_group"].Value = c.Id;
            parameters["group_name"].Value = c.Name;
            parameters["group_description"].Value = c.Comment;
        }
    }
}
