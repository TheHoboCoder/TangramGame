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

        private Garden_groups _teacherGroup;
        public Garden_groups TeacherGroup {
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

        private ListViewAdapter adapter;

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

        public TeacherWorkspace(MySqlConnection connection,User teacher)
        {
            this.teacher = teacher;
            this.connection = connection;

            using (GroupsRepository groups = new GroupsRepository(connection, teacher.Id))
            {
                if (groups.Entities.Count() >= 1)
                {
                    _teacherGroup = groups.Entities.First();
                    
                }
                else
                {
                    _teacherGroup = null;
                }
                
            }

            if (_teacherGroup != null)
            {
                using (ChildrenRepository childs = new ChildrenRepository(connection, _teacherGroup.Id))
                {
                    children = childs.Entities.ToList();
                    SubGroupCount = childs.currentGroupCount;
                }
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
                    children.Clear();
                    children = null;
                    //childrenInGroup.Clear();
                    teacher = null;
                }

                figureGroups.Dispose();
                Figures.Dispose();

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
