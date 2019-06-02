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
    public partial class TabelSettings : Form
    {
        public TabelSettings()
        {
            InitializeComponent();
        }

        private void yearPicker_ValueChanged(object sender, EventArgs e)
        {
            Database.MetWorkspace.GroupManager.groups.FilterByYear((int)yearPicker.Value);
            textBox1.Text = (yearPicker.Value + 1).ToString();
            groupCombo.DisplayMember = "group_name";
            groupCombo.ValueMember = "id_group_h";

            groupCombo.DataSource = Database.MetWorkspace.GroupManager.groups.PureGroups;

            if (Database.MetWorkspace.GroupManager.groups.PureGroups.Count == 0)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void TabelSettings_Load(object sender, EventArgs e)
        {
            MonthCombo.SelectedIndex = 0;
            yearPicker.Value = GroupsRepository.GetWorkYear(DateTime.Now);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int year = (int)yearPicker.Value;

            if (MonthCombo.SelectedIndex+1 >=1 && MonthCombo.SelectedIndex + 1 <= GroupsRepository.END_MONTH)
            {
                year++;
            }
            DateTime start = new DateTime(year, MonthCombo.SelectedIndex + 1, 1);

            Database.Statistics statistics = Database.GetStatistics(Convert.ToInt32(groupCombo.SelectedValue), start, start.AddMonths(1).AddDays(-1));

            if (statistics.attendance.Columns.Count == 1 || statistics.attendance.Rows.Count == 0)
            {
                MessageBox.Show("Нет информации за данный период");
                return;
            }
            WaitForm form = new WaitForm();
            form.Show();
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


            workSheet.Cells[4, 2] = "за " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(start.Month) + " " + start.Year;

            Excel.Range Number = workSheet.Range["A6", "A7"].Cells;
            Number.Merge();
            workSheet.Cells[6, 1] = "№ п.п";

            Excel.Range ChildCaption = workSheet.Range["B6", "B7"].Cells;
            ChildCaption.Merge();
            workSheet.Cells[6, 2] = "Имя ребенка";
            int date_count = statistics.attendance.Columns.Count - 1;

            char endCell = (char)((int)'B' + date_count);

            Excel.Range dateCaption = workSheet.Range["C6", endCell + "6"].Cells;
            dateCaption.Merge();
            workSheet.Cells[6, 3] = "Дата";

            int start_date_cell = 3;

            for (int i = 1; i < statistics.attendance.Columns.Count; i++)
            {
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


            Excel.Range fullTableRange = workSheet.Range["A6", endCell + (start_dt_cell - 1).ToString()].Cells;
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
            form.Close();
            excelApp.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
