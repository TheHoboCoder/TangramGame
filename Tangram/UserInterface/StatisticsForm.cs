using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace Tangram.UserInterface
{
    public partial class StatisticsForm : Form
    {
        DateTime start, end;
        int groupId = -1;
        int maxHeight = 0;
        int bottomChartPos = 0;
        Database.Statistics st;

        public StatisticsForm()
        {
            InitializeComponent();
            maxHeight = diff1_bad_flowchart.Height;
            bottomChartPos = diff1_bad_flowchart.Top + diff1_bad_flowchart.Height;
            LockDatePickers(true);
        }

        private void CreateRepBtn_Click(object sender, EventArgs e)
        {
            if(groupId != -1)
            {
                st = Database.GetStatistics(groupId, startDate.Value, endDate.Value);
                dataGridView1.DataSource = st.mainResult;

                int diff1_total = st.hight_count_diff1 + st.mid_count_diff1 + st.low_count_diff1;

                calculateFlowChartColumn(diff1_bad_flowchart, diff1_bad, diff1_total, st.low_count_diff1);
                calculateFlowChartColumn(diff1_mid_flowchart, diff1_mid_text, diff1_total, st.mid_count_diff1);
                calculateFlowChartColumn(diff1_good_flowchart, diff_1good, diff1_total, st.hight_count_diff1);

                int diff2_total = st.hight_count_diff2 + st.mid_count_diff2 + st.low_count_diff2;

                calculateFlowChartColumn(diff2_bad_flowchart, diff2_bad, diff2_total, st.low_count_diff2);
                calculateFlowChartColumn(diff2_mid_flowchart, diff2_mid, diff2_total, st.mid_count_diff2);
                calculateFlowChartColumn(diff2_good_flowchart, diff_2_good, diff2_total, st.hight_count_diff2);


                tabControl1.Visible = true;
            }
            else
            {

            }
        }


        private void calculateFlowChartColumn(Panel panel, Label caption,int totalCount, int count)
        {
            if (totalCount == 0)
            {
                caption.Text = "Нет данных";
                panel.Height = 0;
                caption.Top = bottomChartPos - caption.Height;
                return;
            }

            float one_percent = (float)totalCount / 100;

            float percentage = count / one_percent;

            
           
            int height = (int)Math.Round((float)maxHeight / 100 * percentage);
            panel.Height = height;
            panel.Top = bottomChartPos - height;
            caption.Text = count + " (" + Math.Round(percentage, 2).ToString() + "%)";
            caption.Top = panel.Top - caption.Height;

        }

        private void periodCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (periodCombo.SelectedIndex) {

                case 0:
                    end = DateTime.Now;
                    start = new DateTime(end.Year, end.Month, 1);
                    endDate.Value = end;
                    UpdateDatePickers();
                    LockDatePickers(true);
                    break;
                case 1:
                    DateTime cur = DateTime.Now;
                    DateTime month = new DateTime(cur.Year, cur.Month, 1);
                    start = month.AddMonths(-1);
                    end = month.AddDays(-1);
                    UpdateDatePickers();
                    LockDatePickers(true);
                    break;
                case 2:

                    if (Database.userRepository.currentUser.UserType == Data.DataModels.User.UserTypes.VOSP)
                    {
                        start = GroupsRepository.GetWorkYearStart(GroupsRepository.GetWorkYear(DateTime.Now));
                        end = GroupsRepository.GetWorkYearEnd(GroupsRepository.GetWorkYear(DateTime.Now));
                    }
                    else
                    {
                        start = GroupsRepository.GetWorkYearStart((int)yearPicker.Value);
                        end = GroupsRepository.GetWorkYearEnd((int)yearPicker.Value);
                    }
                    UpdateDatePickers();
                    LockDatePickers(true);
                    break;
                case 3:
                    LockDatePickers(false);
                    break;
            }

        }

        public void UpdateDatePickers()
        {
            startDate.Value = start;
            endDate.Value = end;
        }

        public void LockDatePickers(bool shouldLock)
        {
            startDate.Enabled = endDate.Enabled = !shouldLock;
        }

        private void yearPicker_ValueChanged(object sender, EventArgs e)
        {
            Database.MetWorkspace.GroupManager.groups.FilterByYear((int)yearPicker.Value);
            

            groupCombo.DisplayMember = "group_name";
            groupCombo.ValueMember = "id_group_h";
            groupCombo.DataSource = Database.MetWorkspace.GroupManager.groups.PureGroups;

            if (Database.MetWorkspace.GroupManager.groups.PureGroups.Count == 0)
            {
                groupCombo.Enabled = false;
                CreateRepBtn.Enabled = false;
            }
            else
            {
                groupCombo.Enabled = true;
                CreateRepBtn.Enabled = true;
                groupCombo.SelectedIndex = 0;
            }

           
        }

        private void groupCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupId = Convert.ToInt32(groupCombo.SelectedValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(groupId == -1)
            {
                MessageBox.Show("Группа не выбрана");
                return;
            }
            DateTime cur = DateTime.Now;
            DateTime month = new DateTime(cur.Year, cur.Month, 1);

            Database.Statistics statistics = Database.GetStatistics(groupId, month.AddMonths(-1), month.AddDays(-1));

            if(statistics.attendance.Columns.Count==1 || statistics.attendance.Rows.Count == 0)
            {
                MessageBox.Show("Нет информации за данный период");
                return;
            }

            Excel.Application excelApp = new Excel.Application();

            Excel.Workbook workBook = excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            workSheet.Name = "Табель посещаемости";

            Excel.Range caption = workSheet.Range["B2", "I2"].Cells;
            caption.Merge();
            workSheet.Cells[2, 2] = "Табель посещаемости";

            Excel.Range groupName = workSheet.Range["B3", "I3"].Cells;
            groupName.Merge();
            
            workSheet.Cells[3, 2] = " группы \"" + groupCombo.Text + "\"";
            
            Excel.Range timePeriod = workSheet.Range["B4", "I4"].Cells;
            timePeriod.Merge();

            Excel.Range fullCaptionRange = workSheet.Range["B2", "I4"].Cells;

            fullCaptionRange.Font.Name = "Times New Roman";
            fullCaptionRange.Font.Size = 16;
            fullCaptionRange.Font.Bold = true;

            fullCaptionRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            fullCaptionRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            fullCaptionRange.EntireColumn.AutoFit();
            fullCaptionRange.EntireRow.AutoFit();


            workSheet.Cells[4,2] = "за " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month.AddMonths(-1).Month) + " " + month.AddMonths(-1).Year;

            Excel.Range Number = workSheet.Range["A6", "A7"].Cells;
            Number.Merge();
            workSheet.Cells[6,1] = "№ п.п";

            Excel.Range ChildCaption = workSheet.Range["B6", "B7"].Cells;
            ChildCaption.Merge();
            workSheet.Cells[6, 2] = "Имя ребенка";
            int date_count = statistics.attendance.Columns.Count - 1;

            char endCell = (char)((int)'B' + date_count);

            Excel.Range dateCaption = workSheet.Range["C6", endCell+"6"].Cells;
            dateCaption.Merge();
            workSheet.Cells[6, 3] = "Дата";

            int start_date_cell = 3;

            for(int i = 1; i < statistics.attendance.Columns.Count; i++){
                workSheet.Cells[7, start_date_cell + (i - 1)] = Convert.ToDateTime(statistics.attendance.Columns[i].ColumnName).ToString("dd");
            }

            int start_dt_cell = 8;
            int counter = 1;

            foreach (DataRow row in statistics.attendance.Rows)
            {
                workSheet.Cells[start_dt_cell, 1] = counter;
                workSheet.Cells[start_dt_cell, 2] = row["child_name"];
                for (int i = 1; i < statistics.attendance.Columns.Count; i++)
                {
                    workSheet.Cells[start_dt_cell, 3 + (i - 1)] = row[i];
                   
                }
                start_dt_cell++;
                counter++;
            }
          

            Excel.Range fullTableRange = workSheet.Range["A6", endCell + (start_dt_cell-1).ToString()].Cells;
            fullTableRange.Font.Name = "Times New Roman";
            fullTableRange.Font.Size = 14;

            fullTableRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            fullTableRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            fullTableRange.EntireColumn.AutoFit();
            fullTableRange.EntireRow.AutoFit();
            fullTableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            Excel.FormatCondition cond =
             (Excel.FormatCondition)fullTableRange.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue,
               Excel.XlFormatConditionOperator.xlEqual, "+",
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            cond.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
            cond.Interior.TintAndShade = 0;
            cond.Interior.Color = ColorTranslator.ToWin32(Color.Green);
            cond.StopIfTrue = false;

            Excel.FormatCondition cond2 =
             (Excel.FormatCondition)fullTableRange.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue,
               Excel.XlFormatConditionOperator.xlEqual, "-",
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            cond2.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
            cond2.Interior.TintAndShade = 0;
            cond2.Interior.Color = ColorTranslator.ToWin32(Color.Tomato);
            cond2.StopIfTrue = false;

            Excel.Range tableCaption = workSheet.Range["A6", endCell + "7"].Cells;
            tableCaption.Font.Bold = true;

            Excel.Range vospName = workSheet.Range["A" + (start_dt_cell + 2), "C" + (start_dt_cell + 2).ToString()];
            vospName.Merge();
            workSheet.Cells[(start_dt_cell + 2), 1] = "Табель составил(-а) " + ((DataRowView)groupCombo.SelectedItem)["fam"];

            

            workSheet.Cells[(start_dt_cell + 2), 6] = "Подпись:";

            excelApp.Visible = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (groupId == -1)
            {
                MessageBox.Show("Группа не выбрана");
                return;
            }


            Database.Statistics statistics = Database.GetStatistics(groupId,  GroupsRepository.GetWorkYearStart((int)yearPicker.Value),
            GroupsRepository.GetWorkYearEnd((int)yearPicker.Value));

            if (statistics.attendance.Rows.Count == 0)
            {
                MessageBox.Show("Нет информации за данный период");
                return;
            }

            Excel.Application excelApp = new Excel.Application();

            Excel.Workbook workBook = excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            workSheet.Name = "Диагностическая карта";

            Excel.Range caption = workSheet.Range["B2", "I2"].Cells;
            caption.Merge();
            workSheet.Cells[2, 2] = "Диагностическая карта занятий";

            Excel.Range groupName = workSheet.Range["B3", "I3"].Cells;
            groupName.Merge();

            workSheet.Cells[3, 2] = " группы \"" + groupCombo.Text + "\"";

            Excel.Range timePeriod = workSheet.Range["B4", "I4"].Cells;
            timePeriod.Merge();

            Excel.Range fullCaptionRange = workSheet.Range["B2", "I4"].Cells;

            fullCaptionRange.Font.Name = "Times New Roman";
            fullCaptionRange.Font.Size = 16;
            fullCaptionRange.Font.Bold = true;

            fullCaptionRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            fullCaptionRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            fullCaptionRange.EntireColumn.AutoFit();
            fullCaptionRange.EntireRow.AutoFit();


            workSheet.Cells[4, 2] = "за " +yearPicker.Value.ToString() +" год";

            Excel.Range Number = workSheet.Range["A6", "A7"].Cells;
            Number.Merge();
            workSheet.Cells[6, 1] = "№ п.п";

            Excel.Range ChildCaption = workSheet.Range["B6", "B7"].Cells;
            ChildCaption.Merge();

            workSheet.Cells[6, 2] = "Имя ребенка";
            workSheet.Cells[6, 3] = "Составление фигур силуэтов по расчлененному образцу";
            workSheet.Cells[7, 3] = "Количество баллов";
            workSheet.Cells[7, 4] = "Уровень освоения";
            workSheet.Cells[6, 5] = "Воссоздание фигур силуэтов по образцам контурного характера";
            workSheet.Cells[7, 5] = "Количество баллов";
            workSheet.Cells[7, 6] = "Уровень освоения";

            Excel.Range diff1 = workSheet.Range["C6", "D6"].Cells;
            diff1.Merge();

            Excel.Range diff2 = workSheet.Range["E6", "F6"].Cells;
            diff2.Merge();

            int start_dt_cell = 8;
            int counter = 1;

            foreach (DataRow row in statistics.mainResult.Rows)
            {
                workSheet.Cells[start_dt_cell, 1] = counter;
                workSheet.Cells[start_dt_cell, 2] = row["childName"];

                if(row["diff_1_result"] == DBNull.Value)
                {
                    workSheet.Cells[start_dt_cell, 3] = "-";
                    workSheet.Cells[start_dt_cell, 4] = "-";
                }
                else
                {
                    double res1 = Math.Round(Convert.ToDouble(row["diff_1_result"]), 2);
                    workSheet.Cells[start_dt_cell, 3] = res1;
                    workSheet.Cells[start_dt_cell, 4] = res1 > 7 ? "Высокий" : res1 > 4 && res1 <= 7 ? "Средний" : "Низкий";
                }

                if (row["diff_2_result"] == DBNull.Value)
                {
                    workSheet.Cells[start_dt_cell, 5] = "-";
                    workSheet.Cells[start_dt_cell, 6] = "-";
                }
                else
                {
                    double res2 = Math.Round(Convert.ToDouble(row["diff_2_result"]), 2);
                    workSheet.Cells[start_dt_cell, 5] = res2;
                    workSheet.Cells[start_dt_cell, 6] = res2 > 7 ? "Высокий" : res2 > 4 && res2 <= 7 ? "Средний" : "Низкий";
                }
                
                start_dt_cell++;
                counter++;
            }


            Excel.Range fullTableRange = workSheet.Range["A6", "F" + (start_dt_cell - 1).ToString()].Cells;
            fullTableRange.Font.Name = "Times New Roman";
            fullTableRange.Font.Size = 14;

            fullTableRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            fullTableRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            fullTableRange.EntireColumn.AutoFit();
            fullTableRange.EntireRow.AutoFit();
            fullTableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            Excel.FormatCondition cond =
             (Excel.FormatCondition)fullTableRange.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue,
               Excel.XlFormatConditionOperator.xlEqual, "Высокий",
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            cond.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
            cond.Interior.TintAndShade = 0;
            cond.Interior.Color = ColorTranslator.ToWin32(Color.Red);
            cond.StopIfTrue = false;

            Excel.FormatCondition cond2 =
             (Excel.FormatCondition)fullTableRange.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue,
               Excel.XlFormatConditionOperator.xlEqual, "Средний",
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            cond2.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
            cond2.Interior.TintAndShade = 0;
            cond2.Interior.Color = ColorTranslator.ToWin32(Color.Green);
            cond2.StopIfTrue = false;

            Excel.FormatCondition cond3 =
             (Excel.FormatCondition)fullTableRange.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue,
               Excel.XlFormatConditionOperator.xlEqual, "Низкий",
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            cond2.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
            cond2.Interior.TintAndShade = 0;
            cond2.Interior.Color = ColorTranslator.ToWin32(Color.Blue);
            cond2.StopIfTrue = false;

            Excel.Range tableCaption = workSheet.Range["A6", "F7"].Cells;
            tableCaption.Font.Bold = true;
            tableCaption.WrapText = true;


            Excel.Range vospName = workSheet.Range["A" + (start_dt_cell + 2), "C" + (start_dt_cell + 2).ToString()];
            vospName.Merge();
            workSheet.Cells[(start_dt_cell + 2), 1] = "Табель составил(-а) " + ((DataRowView)groupCombo.SelectedItem)["fam"];



            workSheet.Cells[(start_dt_cell + 2), 6] = "Подпись:";

            excelApp.Visible = true;
        }

        private void resultsBtn_Click(object sender, EventArgs e)
        {
            TeacherResultViewer viewer = new TeacherResultViewer();
            viewer.Show();
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            endDate.MinDate = startDate.Value;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            periodCombo.SelectedIndex = 0;
            end = DateTime.Now;
            start = new DateTime(end.Year, end.Month,1);
            tabControl1.Visible = false;

            if(Database.userRepository.currentUser.UserType== Data.DataModels.User.UserTypes.VOSP)
            {
                MetPanel.Visible = false;
                reportViewers.Visible = false;
                groupId = Database.Teacher_Workspace.TeacherGroup;
                resultsBtn.Visible = true;
                resultsBtn.Left = dataGridView1.Left;
            }
            else
            {
                yearPicker.Value = GroupsRepository.GetWorkYear(DateTime.Now);
                //Database.MetWorkspace.GroupManager.groups.FilterByYear((int)yearPicker.Value);
                //groupCombo.DataSource = Database.MetWorkspace.GroupManager.groups.PureGroups;

                //groupCombo.DisplayMember = "group_name";
                //groupCombo.ValueMember = "id_group_h";
                //groupCombo.SelectedIndex = 0;
                MetPanel.Visible = true;
                reportViewers.Visible = true;
                resultsBtn.Visible = false;

            }
        }
    }
}
