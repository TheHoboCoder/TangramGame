using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangram.Data.DataModels;

namespace Tangram.Data
{
    public class ChildHelper:IDisposable
    {

        private MySqlConnection connection;

        public ChildrenRepository children { get; private set; }
        public ChildJournalRepository childJournal { get; private set; }

        public ChildHelper(MySqlConnection connection)
        {
            this.connection = connection;
            children = new ChildrenRepository(connection);
            childJournal = new ChildJournalRepository(connection);
        }

        public bool Add(Child child, Child_Journal journalItem)
        {
            MySqlTransaction tr = connection.BeginTransaction();
            children.StartTransaction(tr);
            childJournal.StartTransaction(tr);

            int insertId = children.Add(child);
            if (insertId == -1)
            {
                tr.Rollback();
                children.EndTransacation();
                childJournal.EndTransacation();
                return false;
            }
            else
            {
                journalItem.ChildId= insertId;
                if (childJournal.Add(journalItem) == -1)
                {
                    tr.Rollback();
                    children.EndTransacation();
                    childJournal.EndTransacation();
                    return false;
                }
                else
                {
                    tr.Commit();
                }
            }
            children.EndTransacation();
            childJournal.EndTransacation();
            children.UpdateTable();
            return true;
        }


        public bool Delete(int childId)
        {
            List<int> deleteInd = new List<int>();
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select id_journal from child_journal where id_child='" + childId.ToString() + "'";


                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    deleteInd.Add(reader.GetInt32(0));
                }
            }

            MySqlTransaction tr = connection.BeginTransaction();
            children.StartTransaction(tr);
            childJournal.StartTransaction(tr);


            foreach (int ind in deleteInd)
            {
                if (!childJournal.Delete(ind))
                {
                    tr.Rollback();
                    children.EndTransacation();
                    childJournal.EndTransacation();
                    return false;
                }
            }

            if (!children.Delete(childId))
            {
                tr.Rollback();
                children.EndTransacation();
                childJournal.EndTransacation();
                return false;
            }
            else
            {
                tr.Commit();
            }

            children.EndTransacation();
            childJournal.EndTransacation();
            children.GetData();
            return true;
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
                children.Dispose();
                childJournal.Dispose();
                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        ~ChildHelper()
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

