using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangram.Data.DataModels;

namespace Tangram.Data
{
    public class GroupHelper:IDisposable
    {
        private MySqlConnection connection;

        public  HistoryRepository history { get; private set; }

        public GroupsRepository groups { get; private set; }

        public GroupHelper(MySqlConnection connection)
        {
            this.connection = connection;
            history = new HistoryRepository(connection);
            groups = new GroupsRepository(connection);
        }

        public bool Add(Garden_groups group, History_group gr)
        {
            MySqlTransaction tr  = connection.BeginTransaction();
            history.StartTransaction(tr);
            groups.StartTransaction(tr);

            int insertId = groups.Add(group);
            if(insertId == -1)
            {
                tr.Rollback();
                history.EndTransacation();
                groups.EndTransacation();
                return false;
            }
            else
            {
                gr.GroupId = insertId;
                if (history.Add(gr) == -1)
                {
                    tr.Rollback();
                    history.EndTransacation();
                    groups.EndTransacation();
                    return false;
                }
                else
                {
                    tr.Commit();
                }
            }
            history.EndTransacation();
            groups.EndTransacation();
            groups.UpdateTable();
            return true;

        }


        public bool Delete(int groupId)
        {
            List<int> deleteInd = new List<int>();
            using (MySqlCommand command = new MySqlCommand())
            {
                    command.Connection = connection;
                    command.CommandText = "select id_group_h from group_history where id_group='" + groupId.ToString() + "'";
                  
                    MySqlDataReader reader = command.ExecuteReader();
                    
                     while (reader.Read())
                     {
                        deleteInd.Add(reader.GetInt32(0));
                     }
             }

            MySqlTransaction tr = connection.BeginTransaction();
            history.StartTransaction(tr);
            groups.StartTransaction(tr);


            foreach(int ind in deleteInd)
            {
                if (!history.Delete(ind))
                {
                    tr.Rollback();
                    history.EndTransacation();
                    groups.EndTransacation();
                    return false;
                }
            }

            if (!groups.Delete(groupId))
            {
                tr.Rollback();
                history.EndTransacation();
                groups.EndTransacation();
                return false;
            }
            else
            {
                tr.Commit();
            }

            history.EndTransacation();
            groups.EndTransacation();
            groups.UpdateTable();
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
                history.Dispose();
                groups.Dispose();

                disposedValue = true;
            }
        }

        //TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
         ~GroupHelper()
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
