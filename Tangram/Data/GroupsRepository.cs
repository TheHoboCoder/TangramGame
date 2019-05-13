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
    public class GroupsRepository : Repository<Garden_groups>
    {
        const int START_MONTH = 10;
        const int START_DAY = 1;
        const int END_MONTH = 5;
        const int END_DAY = 15;

        private TableInfo groupInfo;
        public DataView PureGroups { get; private set; }

        protected override TableInfo info => groupInfo;

        public GroupsRepository(MySqlConnection connection) : base(connection, false)
        {
            groupInfo = new TableInfo();

            groupInfo.parameters.Add(new MySqlParameter("id_group", MySqlDbType.Int32));
            groupInfo.parameters.Add(new MySqlParameter("group_name", MySqlDbType.VarChar));
            groupInfo.parameters.Add(new MySqlParameter("group_type_id", MySqlDbType.Int32));

            groupInfo.TableName = "garden_groups";
            groupInfo.IdName = "id_group";
            groupInfo.GenerateStatements();

            RepeatErrorMsg = "Название группы не должно повторяться";
            DeleteErrorMsg = "Не удалось удалить группу";
            InsertErrorMsg = "Не удалось добавить группу";
            UpdateErrorMsg = "Не удалось изменить группу";
           //groupInfo.linkedTables.Add("childs");
           PureGroups = new DataView(Table);
            InitCommandParameters();
            AutoUpload = false;
            FilterByYear(GroupsRepository.GetWorkYear(DateTime.Now));
        }


        //public Garden_groups GetGroupByTeacherId(int userId)
        //{
        //        Table.Select(String.Format("id_user= '{0}'", id));
        //        return MapOut(Table.Rows[0]);
        //}

        public void FilterGroupsByType(int groupTypeId)
        {
            filteredTable.RowFilter = "group_type_id= " + groupTypeId;
        }

       

        public static int GetWorkYear(DateTime date)
        {
            int year = date.Year;

            DateTime startDate = new DateTime(date.Year, 1, 1);
            DateTime endDate = new DateTime(date.Year, END_MONTH, END_DAY);

            if (date >= startDate && date <= endDate)
            {
                --year;
            }

            return year;
        }

        public static DateTime GetWorkYearStart(int year)
        {
            return new DateTime(year, START_MONTH, START_DAY);

        }

        public static DateTime GetWorkYearEnd(int year)
        {
            return new DateTime(++year, END_MONTH, END_DAY);

        }

        public void UpdatePureGroups()
        {
            PureGroups.RowFilter = "id_user is not null";
        }


        public void FilterByYear(int year)
        {

            groupInfo.SelectStatement = String.Format(@"SELECT garden_groups.id_group,
                                                 garden_groups.group_name, 
	                                             group_type.group_type_name, 
                                                 group_history.id_group_h,
                                                 group_type.group_type_id,
                                                 group_history.id_user, 
                                                 group_history.history_year,
                                                 if (users.fam is null, '<Не назначен>',
                                                    CONCAT(`users`.`fam`,
                                                    ' ',
                                                    UPPER(LEFT(`users`.`name`, 1)),
                                                   '.',
                                                   UPPER(LEFT(`users`.`otch`, 1)))) as 'fam',
                                                (select count(*)  from child_journal where id_group_h = group_history.id_group_h) as 'count'
                                       FROM garden_groups
                                       inner join group_type on garden_groups.group_type_id = group_type.group_type_id
                                       left  join group_history on group_history.id_group = garden_groups.id_group
                                                                and group_history.history_year = '{0}' or group_history.history_year is null
                                       left join users on group_history.id_user = users.id_user", year);
           
            Upload();
            UpdatePureGroups();
        }

        protected override Garden_groups MapOut(DataRow row)
        {
            Garden_groups groups = new Garden_groups()
            {
                Id = Convert.ToInt32(row["id_group"]),
                Group_Name = row["group_name"].ToString(),
                GroupTypeId = Convert.ToInt32(row["group_type_id"])
                //childCount = Convert.ToInt32(row["count"]),
                //TeacherId = Convert.ToInt32(row["id_user"])
            };
            return groups;
        }


        protected override void SetCommandParameters(Garden_groups c, MySqlParameterCollection parameters)
        {
            parameters["id_group"].Value = c.Id;
            parameters["group_name"].Value = c.Group_Name;
            parameters["group_type_id"].Value = c.GroupTypeId;
            //parameters["count"].Value = c.childCount;
            //parameters["id_user"].Value = c.TeacherId;
        }
    }
}
