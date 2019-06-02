using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.Data;
using Tangram.Data.DataModels;
using Excel = Microsoft.Office.Interop.Excel;

namespace Tangram.UserInterface
{
    public partial class ResultsViewer : UserControl
    {
        bool timeSelected = false;
        bool filtered = false;

        public ResultsViewer()
        {
            InitializeComponent();
        }


        //Обработчик загрузки панели.
        private void ResultsViewer_Load(object sender, EventArgs e)
        {
           
            periodCombo.SelectedIndex = 0;
            Database.GameRepository.GetInfo();
            if (Database.userRepository.currentUser.UserType == Data.DataModels.User.UserTypes.VOSP)
            {
                teacherFilterCombo.DisplayMember = "Initials";
                teacherFilterCombo.ValueMember = "Id";
                teacherFilterCombo.DataSource = new List<User>() { Database.userRepository.currentUser };
                filtered = true;
                teacherFilterCombo.SelectedItem = Database.userRepository.currentUser;
                //teacherFilterCombo.Text = Database.userRepository.currentUser.Initials;
                //teacherFilterCombo.SelectedValue = Database.userRepository.currentUser.Id;
                //teacherFilterCombo.SelectedIndex = 0;
                teacherFilterCombo.Enabled = false;
                teacherCheckBox.Checked = true;
                teacherCheckBox.Enabled = false;
                Database.GameRepository.FilterByTeacherId(Convert.ToInt32(teacherFilterCombo.SelectedValue));
                ResultGridView.DataSource = Database.GameRepository.filteredTable;

                childFilterCombo.DisplayMember = "FullName";
                childFilterCombo.ValueMember = "Id";

                childFilterCombo.DataSource = Database.Teacher_Workspace.children;
                DeleteBtn.Enabled = DeleteCurr.Enabled = false;

            }
            else
            {
                Database.userRepository.FilterUsersByType(Data.DataModels.User.UserTypes.VOSP);
                teacherFilterCombo.DisplayMember = "usersInitials";
                teacherFilterCombo.ValueMember = "id_user";
                teacherFilterCombo.DataSource = Database.userRepository.filteredTable;
                childFilterCombo.DisplayMember = "FullName";
                childFilterCombo.ValueMember = "Id";
                childFilterCombo.DataSource = Database.MetWorkspace.ChildManager.children.getDistinctChildren();
                ResultGridView.DataSource = Database.GameRepository.Table;

                EditBtn.Enabled = false;
            }
        }

        //Обработчик загрузки панели.
        private void ShowAllBtn_Click(object sender, EventArgs e)
        {
            filtered = false;
            if (Database.userRepository.currentUser.UserType == Data.DataModels.User.UserTypes.VOSP)
            {
                Database.GameRepository.FilterByTeacherId(Convert.ToInt32(teacherFilterCombo.SelectedValue));
                ResultGridView.DataSource = Database.GameRepository.filteredTable;
            }
            else
            {
                ResultGridView.DataSource = Database.GameRepository.Table;
            }
                
        }

        //Обработчик изменения начальной даты
        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            endDate.MinDate = startDate.Value;
        }

        //Обработчик нажатия на кнопку "Фильтровать"
        private void periodCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(periodCombo.SelectedIndex){

                case 0:
                    timeSelected = false;
                    startDate.Enabled = endDate.Enabled = false;
                    break;
                case 1:
                    timeSelected = true;
                    endDate.Value = DateTime.Now;
                    startDate.Value = new DateTime(endDate.Value.Year, endDate.Value.Month, 1);
                    startDate.Enabled = endDate.Enabled = false;
                    break;
                case 2:
                    timeSelected = true;
                    DateTime cur = DateTime.Now;
                    DateTime month = new DateTime(cur.Year, cur.Month, 1);
                    startDate.Value = month.AddMonths(-1);
                    endDate.Value = month.AddDays(-1);
                    startDate.Enabled = endDate.Enabled = false;
                    break;
                case 3:
                    timeSelected = true;
                    startDate.Value = GroupsRepository.GetWorkYearStart(GroupsRepository.GetWorkYear(DateTime.Now));
                    endDate.Value = GroupsRepository.GetWorkYearEnd(GroupsRepository.GetWorkYear(DateTime.Now));
                    startDate.Enabled = endDate.Enabled = false;
                    break;
                case 4:
                    timeSelected = true;
                    startDate.Enabled = endDate.Enabled = true;
                    break;

            }
        }

        //Обработчик изменения значения в выпадающем списке "Период времени"
        private void FilterBtn_Click(object sender, EventArgs e)
        {
            filtered = true;
            if(childCheckBox.Checked && teacherCheckBox.Checked && timeSelected)
            {
                Database.GameRepository.Filter(Convert.ToInt32(childFilterCombo.SelectedValue), Convert.ToInt32(teacherFilterCombo.SelectedValue), startDate.Value, endDate.Value);
            }

            if(childCheckBox.Checked && teacherCheckBox.Checked && !timeSelected)
            {
                Database.GameRepository.Filter(Convert.ToInt32(childFilterCombo.SelectedValue), Convert.ToInt32(teacherFilterCombo.SelectedValue));
            }

            if (!childCheckBox.Checked && teacherCheckBox.Checked && timeSelected)
            {
                Database.GameRepository.FilterTeacher(Convert.ToInt32(teacherFilterCombo.SelectedValue), startDate.Value, endDate.Value);
            }

            if (childCheckBox.Checked && !teacherCheckBox.Checked && timeSelected)
            {
                Database.GameRepository.FilterChild(Convert.ToInt32(childFilterCombo.SelectedValue), startDate.Value, endDate.Value);
            }

            if (childCheckBox.Checked && !teacherCheckBox.Checked && !timeSelected)
            {
                Database.GameRepository.FilterByChildId(Convert.ToInt32(childFilterCombo.SelectedValue));
            }

            if (!childCheckBox.Checked && teacherCheckBox.Checked && !timeSelected)
            {
                Database.GameRepository.FilterByTeacherId(Convert.ToInt32(teacherFilterCombo.SelectedValue));
            }

            if (!childCheckBox.Checked && !teacherCheckBox.Checked && timeSelected)
            {
                Database.GameRepository.FilterByPeriod(startDate.Value, endDate.Value);
            }
            ResultGridView.DataSource = Database.GameRepository.filteredTable;

        }

        //Обработчик нажатия на кнопку «Редактировать», открывает форму для редактирования результатов игр
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (ResultGridView.SelectedRows.Count != 0)
            {
                DataRow row = Database.GameRepository.GetRowById(Convert.ToInt32(ResultGridView.SelectedRows[0].Cells["Id"].Value));
                Result res = Database.GameRepository.MapOut(row);
                ResultEdit resultEdit = new ResultEdit(res);
                resultEdit.ShowDialog();
                resultEdit.Dispose();
            }
        }

        //Обработчик нажатия на кнопку «Удалить», удаляет текущую запись
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (ResultGridView.SelectedRows.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Удалить результат занятия?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    Database.GameRepository.Delete(Convert.ToInt32(ResultGridView.SelectedRows[0].Cells["Id"].Value));
                    Database.GameRepository.UpdateRelatedClasses();
                }
            }
               
        }

        //Обработчик нажатия на кнопку «Удалить все», удаляет все записи в таблице
        private void DeleteCurr_Click(object sender, EventArgs e)
        {
            int count = 0;

            if (filtered)
            {
                count = Database.GameRepository.filteredTable.Count;
            }
            else
            {
                count = Database.GameRepository.Table.Rows.Count;
            }

            if (count == 0) return;

            if (DialogResult.Yes == MessageBox.Show("Удалить текущие "+count+ " записей(-и)?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if(DialogResult.Yes == MessageBox.Show("Экспортировать данные перед удалением?", "Экспорт", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    CreateExcelDoc();
                }

                if (filtered)
                {
                   foreach(DataRowView rowView in Database.GameRepository.filteredTable)
                   {
                        Database.GameRepository.Delete(Convert.ToInt32(rowView.Row["id_result"]));
                   }
                    
                }
                else
                {
                    while(Database.GameRepository.Table.Rows.Count !=0)
                    {
                        Database.GameRepository.Delete(Convert.ToInt32(Database.GameRepository.Table.Rows[0]["id_result"]));
                    }
                }

                Database.GameRepository.UpdateRelatedClasses();

                MessageBox.Show("Данные были успешно удаленны", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }


        }

        //Выполняет экспорт результатов игр в Excel
        public void CreateExcelDoc()
        {
            if(filtered&&Database.GameRepository.filteredTable.Count==0 || Database.GameRepository.Table.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Excel.Application excelApp = new Excel.Application();
            WaitForm form = new WaitForm();
            form.Show();
            Excel.Workbook workBook = excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            workSheet.Name = "Экспорт данных за " + DateTime.Now.ToShortDateString();

            workSheet.Cells[1, 1] = "Результаты игр за период c " + startDate.Value.ToShortDateString() + " по " + endDate.Value.ToShortDateString();
            Excel.Range caption = workSheet.Range["A1", "F1"].Cells;
            caption.Font.Name = "Times New Roman";
            caption.Font.Size = 14;
            caption.Font.Bold = true;
            caption.Merge();
            caption.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            caption.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            caption.EntireColumn.AutoFit();
            caption.EntireRow.AutoFit();

            workSheet.Cells[2, 1] = "Имя ребёнка ";
            workSheet.Cells[2, 2] = "Воспитатель ";
            workSheet.Cells[2, 3] = "Группа ";
            workSheet.Cells[2, 4] = "Дата проведения занятия ";
            workSheet.Cells[2, 5] = "Количество баллов ";
            workSheet.Cells[2, 6] = "Уровень сложности ";

            int start_dt_cell = 3;
       

            if (filtered)
            {
                foreach (DataRowView row in Database.GameRepository.filteredTable)
                {
                    workSheet.Cells[start_dt_cell, 1] = row.Row["childName"];
                    workSheet.Cells[start_dt_cell, 2] = row.Row["fam"];
                    workSheet.Cells[start_dt_cell, 3] = row.Row["group_name"];
                    workSheet.Cells[start_dt_cell, 4] = row.Row["class_date"];
                    workSheet.Cells[start_dt_cell, 5] = row.Row["score"];
                    workSheet.Cells[start_dt_cell, 6] = row.Row["level_name"];

                    start_dt_cell++;
                }
            }
            else
            {
                foreach (DataRow row in Database.GameRepository.Table.Rows)
                {
                    workSheet.Cells[start_dt_cell, 1] = row["childName"];
                    workSheet.Cells[start_dt_cell, 2] = row["fam"];
                    workSheet.Cells[start_dt_cell, 3] = row["group_name"];
                    workSheet.Cells[start_dt_cell, 4] = row["class_date"];
                    workSheet.Cells[start_dt_cell, 5] = row["score"];
                    workSheet.Cells[start_dt_cell, 6] = row["level_name"];

                    start_dt_cell++;
                }
            }


            Excel.Range fullTableRange = workSheet.Range["A2", "F" + (start_dt_cell - 1).ToString()].Cells;
            fullTableRange.Font.Name = "Times New Roman";
            fullTableRange.Font.Size = 14;

            fullTableRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            fullTableRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            fullTableRange.EntireColumn.AutoFit();
            fullTableRange.EntireRow.AutoFit();
            fullTableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            Excel.Range tableCaption = workSheet.Range["A1", "F1"].Cells;
            tableCaption.Font.Bold = true;
            tableCaption.WrapText = true;
            form.Close();
            excelApp.Visible = true;
        }

        //Обработчик нажатия на кнопку «Экспорт»
        private void ExportBtn_Click(object sender, EventArgs e)
        {
            CreateExcelDoc();
        }
    }
}
