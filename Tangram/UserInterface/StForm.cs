using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace Tangram.UserInterface
{
    public partial class StForm : Form
    {
        public StForm()
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

        private void StForm_Load(object sender, EventArgs e)
        {
            yearPicker.Value = GroupsRepository.GetWorkYear(DateTime.Now);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.Statistics statistics = Database.GetStatistics(Convert.ToInt32(groupCombo.SelectedValue), GroupsRepository.GetWorkYearStart((int)yearPicker.Value),
            GroupsRepository.GetWorkYearEnd((int)yearPicker.Value));

            if (statistics.mainResult.Rows.Count == 0)
            {
                MessageBox.Show("Нет информации за данный период");
                return;
            }

            WaitForm form = new WaitForm();
            form.Show();
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


            workSheet.Cells[4, 2] = "за " + yearPicker.Value.ToString() + " - "+textBox1.Text+" учебный год";

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

                if (row["diff_1_result"] == DBNull.Value)
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
            form.Close();
            excelApp.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
