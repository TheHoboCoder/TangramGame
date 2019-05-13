using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Tangram.Data.DataModels
{
    public class GameRepository : Repository<Result>
    {
        private TableInfo resultInfo;
        protected override TableInfo info => resultInfo;

        public GameRepository(MySqlConnection connection) : base(connection, false)
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

            resultInfo.SelectStatement = @"select  concat(childs.name, ' ', childs.fam) as 'childName', 
                                                   childs.id_child,
                                                   CONCAT(`users`.`fam`,
                                                          ' ',
                                                          UPPER(LEFT(`users`.`name`, 1)),
                                                          '.',
                                                          UPPER(LEFT(`users`.`otch`, 1))) as 'fam', 
                                                   users.id_user,
                                                   garden_groups.group_name,
                                                   classes.class_date,
                                                   results.score,
                                                   difficulty_levels.level_name
                                          from results
                                          inner join classes on results.id_class = classes.id_class
                                          inner join childs on results.id_child = childs.id_child
                                          inner join difficulty_levels on results.id_level = difficulty_levels.id_level
                                          inner join users on classes.id_user = users.id_user
                                          inner join group_history on results.id_group_h = group_history.id_group_h
                                          inner join garden_groups on group_history.id_group = garden_groups.id_group";


            InitCommandParameters();

        }

        public void GetInfo()
        {
            Upload();
        }


        public void FilterByChildId(int id)
        {
            filteredTable.RowFilter = "id_child = '" + id + "'";
        }

        public void FilterByTeacherId(int id)
        {
            filteredTable.RowFilter = "id_user = '" + id + "'";
        }

        public void FilterByPeriod(DateTime start, DateTime end)
        {
            filteredTable.RowFilter = "class_date >= #" + start.ToString("MM/dd/yyyy") + "# and class_date <= #"+ end.ToString("MM/dd/yyyy") + "#";
        }

        public void Filter(int childId, int teacherId)
        {
            filteredTable.RowFilter = "id_child = '" + childId + "'  and id_user = '" + teacherId + "'";
        }

        public void Filter(int childId, int teacherId, DateTime start, DateTime end)
        {
            filteredTable.RowFilter = "id_child = '" + childId + "'  and id_user = '" + teacherId + "' and class_date >= #" + start.ToString("MM/dd/yyyy") + "# and class_date <= #" + end.ToString("MM/dd/yyyy") + "#"; 
        }

        public void FilterChild(int childId,DateTime start, DateTime end)
        {
            filteredTable.RowFilter = "id_child = '" + childId + "' and class_date >= #" + start.ToString("MM/dd/yyyy") + "# and class_date <= #" + end.ToString("MM/dd/yyyy") + "#";
        }

        public void FilterTeacher(int teacherId, DateTime start, DateTime end)
        {
            filteredTable.RowFilter = "id_user = '" + teacherId + "' and class_date >= #" + start.ToString("MM/dd/yyyy") + "# and class_date <= #" + end.ToString("MM/dd/yyyy") + "#";
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
