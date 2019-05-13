using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangram.Data.DataModels;

namespace Tangram.Data
{
    public class MetWorkspace:IDisposable
    {
        private MySqlConnection connection;

        public GroupTypeRepository GroupTypes{ get; private set; }
        public GroupHelper GroupManager { get; private set; }
        public ChildHelper ChildManager { get; private set; }
        public GameRepository Results { get; private set; }
        public User Met { get; private set; }

        public MetWorkspace(MySqlConnection connection, User met)
        {
            this.connection = connection;

            GroupTypes = new GroupTypeRepository(connection);
            GroupManager = new GroupHelper(connection);
            ChildManager = new ChildHelper(connection);
            Results = new GameRepository(connection);
            Met = met;

        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                GroupTypes.Dispose();
                ChildManager.Dispose();
                GroupManager.Dispose();
                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        ~MetWorkspace()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(false);
        }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
