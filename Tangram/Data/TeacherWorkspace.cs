using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangram.Data.DataModels;
using System.Windows.Forms;

namespace Tangram.Data
{
    class TeacherWorkspace:IDisposable
    {
        private MySqlConnection connection;

        private int _teacherGroup;
        public int TeacherGroup {
            get {
                return _teacherGroup;
            }
        }

        public User teacher;

        public FigureGroupsRepository figureGroups;

        private FigureRepository figures;
        public FigureRepository Figures
        {
            get
            {
                if (figures == null)
                    figures = new FigureRepository(connection);
                return figures;
            }
        }

        public GameRepository gameRepository { get; private set;  }
        

        private ListViewAdapter adapter;

        public ListViewAdapter ViewAdapter { get { return adapter;  } }

        public void InitListView(ListView listView)
        {
            adapter = new ListViewAdapter(figureGroups.Entities.ToList(), Figures.Entities.ToList(), listView,teacher.Id);
        }


        public List<Child> children { get; private set; }

        public int SubGroupCount { get; private set; }

        public List<Child> childrenInGroup { get; set; }

        public int CurrentClassId { get; private set; }

        public bool BeginClass()
        {
            using(MySqlCommand command = new MySqlCommand())
            {
                command.Connection = connection;
                try
                {
                    command.CommandText = String.Format("select id_class from tangram.classes where  id_user = '{0}' and class_date = '{1}'", teacher.Id, DateTime.Now.ToString("yyyy-MM-dd"));
                    Object res = command.ExecuteScalar();
                    if (res == null)
                    {
                        command.CommandText = String.Format("insert into tangram.classes (id_user, class_date) values ('{0}','{1}')", teacher.Id, DateTime.Now.ToString("yyyy-MM-dd"));
                        command.ExecuteNonQuery();
                        CurrentClassId = (int)command.LastInsertedId;
                    }
                    else
                    {
                        CurrentClassId = Convert.ToInt32(res);
                    }
                    return true;
                }
                catch (MySqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка базы данных №" + ex.Number);
                    return false;
                }
            }
            
        }

        public void EndClass()
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = connection;
                try
                {
                    command.CommandText = "select count(*) from results where id_class = '" + CurrentClassId + "'";
                    int res = Convert.ToInt32(command.ExecuteScalar());
                    if (res == 0)
                    {
                        command.CommandText = "delete from classes where id_class = '" + CurrentClassId + "'";
                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка базы данных №" + ex.Number);
                }
            }
        }

        public TeacherWorkspace(MySqlConnection connection,User teacher)
        {
            this.teacher = teacher;
            this.connection = connection;

            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = connection;

                command.CommandText = String.Format("select id_group_h from group_history where id_user = '{0}' and history_year='{1}'", teacher.Id, GroupsRepository.GetWorkYear(DateTime.Now));
                Object res = command.ExecuteScalar();

                if (res != null)
                {
                    _teacherGroup = Convert.ToInt32(res);
                }
                else
                {
                    _teacherGroup = -1;
                }  
            }

            if (_teacherGroup != -1)
            {
                using (ChildrenRepository childs = new ChildrenRepository(connection, _teacherGroup))
                {
                    children = childs.Entities.ToList();
                    SubGroupCount = childs.currentGroupCount;
                }
                gameRepository = new GameRepository(connection);
            }

            figureGroups = new FigureGroupsRepository(connection);
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    children?.Clear();
                    children = null;
                    //childrenInGroup.Clear();
                    teacher = null;
                }

                figureGroups?.Dispose();
                Figures?.Dispose();
                adapter?.Dispose();
                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~TeacherWorkspace() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
