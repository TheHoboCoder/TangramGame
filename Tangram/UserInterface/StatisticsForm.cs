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
        DateTime start, end; //дата начала и конца периода
        int groupId = -1; // идентификатор текущей группа
        int maxHeight = 0; //максимальная высота колонки диаграммы
        int bottomChartPos = 0; //позиция колонки
        Database.Statistics st; //структура, хранит статистику

        public StatisticsForm()
        {
            InitializeComponent();
            maxHeight = diff1_bad_flowchart.Height;
            bottomChartPos = diff1_bad_flowchart.Top + diff1_bad_flowchart.Height;
            LockDatePickers(true);
        }

        //Обработчик нажатия на кнопку "Cформировать", закружает статистику по играм, а также создает диаграмму по играм
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


        //Вычисляет размер колонки диаграммы
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

        //обработчик изменения значения в выпадающем спсике "Период времени"
        private void periodCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (periodCombo.SelectedIndex) {

                case 0:
                    end = DateTime.Now;
                    start = new DateTime(end.Year, end.Month, 1);
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

        //обновляет значения в компонентах для выбора начальной и конечной дат
        public void UpdateDatePickers()
        {
            startDate.Value = start;
            endDate.Value = end;
        }

        //блокирует компоненты для выбора начальной и конечной дат
        public void LockDatePickers(bool shouldLock)
        {
            startDate.Enabled = endDate.Enabled = !shouldLock;
        }

        //обработчик изменения значения в поле "Учебный год"
        private void yearPicker_ValueChanged(object sender, EventArgs e)
        {
            Database.MetWorkspace.GroupManager.groups.FilterByYear((int)yearPicker.Value);

            textBox1.Text = (yearPicker.Value + 1).ToString();

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

        //обработчик изменения значения в выпадающем списке "Группы"
        private void groupCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupId = Convert.ToInt32(groupCombo.SelectedValue);
        }

        //обработчик нажатия на кнопку "Табель посещаемости", формирует выходной документ "Табель посещаемости"
        private void button3_Click(object sender, EventArgs e)
        {
            TabelSettings settings = new TabelSettings();
            settings.ShowDialog();

        }


        //обработчик нажатия на кнопку "Отчет об успеваемости", формирует выходной документ "Отчет об успеваемости"
        private void button2_Click(object sender, EventArgs e)
        {
            StForm form = new StForm();
            form.ShowDialog();


            
        }

        //Обработчик нажатия на кнопку "Результаты"
        private void resultsBtn_Click(object sender, EventArgs e)
        {
            TeacherResultViewer viewer = new TeacherResultViewer();
            viewer.Show();
        }


        //Обработчик изменения начальной даты
        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            endDate.MinDate = startDate.Value;
        }


        //Обработчик загрузки формы
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
