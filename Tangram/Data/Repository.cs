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
    public abstract class Repository<TEntity>: IDisposable
    {
        private MySqlCommand command = new MySqlCommand();

        public DataTable Table { get; protected set; }
        public DataView filteredTable { get; private set; }
        private TableInfo info;

        public string RepeatErrorMsg { get; set; }
        public string UpdateErrorMsg { get; set; }
        public string DeleteErrorMsg { get; set; }
        public string InsertErrorMsg { get; set; }

        protected virtual string linkedErrorMsg(string table)
        {
            return "Данная запись уже используется в таблице \"" + table + "\"!";
        }


        private bool _checkOnDelete;
        public bool CheckOnDelete
        {
            get
            {
                return _checkOnDelete;
            }
            set
            {
                _checkOnDelete = value;
            }
        }

        public Repository(MySqlConnection connection,TableInfo info)
        {
            command.Connection = connection;
            this.info = info;
            Table = new DataTable();

            RepeatErrorMsg = "Значение не должно повторяться!";
            DeleteErrorMsg = "Не удалось удалить запись!";
            UpdateErrorMsg = "Не удалось обновить запись!";
            InsertErrorMsg = "Не удалось добавить запись!";

            CheckOnDelete = true;
            InitCommandParameters();
            filteredTable = new DataView(Table);
          
        }

        protected bool Upload(string condition = null)
        {
            try
            {
                command.CommandText = info.SelectStatement;

                if (condition != null)
                {
                    command.CommandText += " where " + condition;
                }

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {

                    command.ExecuteNonQuery();
                    Table.Clear();
                    adapter.Fill(Table);
                }
                return true;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось загрузить данные!",
                                                                           "Ошибка " + ex.Number,
                                                                           System.Windows.Forms.MessageBoxButtons.OK,
                                                                           System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        private void InitCommandParameters()
        {
            foreach (var  parameter in info.parameters)
            {
                command.Parameters.Add(parameter);
            }

        }

        protected abstract void SetCommandParameters(TEntity c,MySqlParameterCollection parameters);
        protected abstract TEntity MapOut(DataRow row);

        private DataRow UploadRow(int id)
        {
            using (DataTable dt = new DataTable())
            {
                command.CommandText = info.SelectStatement + " where " + info.IdName + "= '" + id + "'";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    command.ExecuteNonQuery();
                    adapter.Fill(dt);
                    return dt.Rows[0];
                }
            }
        }

        public int Add(TEntity c)
        {
            SetCommandParameters(c,command.Parameters);
            command.CommandText = info.InsertStatement;
            try
            {
                command.ExecuteNonQuery();
                command.CommandText = "select last_insert_id();";
                int newId =  Convert.ToInt32(command.ExecuteScalar());
                Table.ImportRow(UploadRow(newId));
                return newId;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    System.Windows.Forms.MessageBox.Show(RepeatErrorMsg,
                                                           "Ошибка ",
                                                           System.Windows.Forms.MessageBoxButtons.OK,
                                                           System.Windows.Forms.MessageBoxIcon.Error);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(InsertErrorMsg,
                                                           "Ошибка " + ex.Number,
                                                           System.Windows.Forms.MessageBoxButtons.OK,
                                                           System.Windows.Forms.MessageBoxIcon.Error);
                }
                return -1;
            }

        }

        public bool Delete(int deleteId)
        {
            try
            {
                command.Parameters[info.IdName].Value = deleteId;
                

                if (_checkOnDelete)
                {
                    foreach (string table in info.linkedTables)
                    {
                        command.CommandText = String.Format("Select count(*) from {0} where {1} = @{1}", table, info.IdName);
                        Object c = command.ExecuteScalar();
                        if (c == null) continue;
                        int rowCount = Convert.ToInt32(c);
                        if (rowCount > 0)
                        {
                            System.Windows.Forms.MessageBox.Show(linkedErrorMsg(table),
                                                          DeleteErrorMsg,
                                                          System.Windows.Forms.MessageBoxButtons.OK,
                                                          System.Windows.Forms.MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }

                command.CommandText = info.DeleteStatement;
                command.ExecuteNonQuery();
                DataRow row = GetRowById(deleteId);
                if (row != null)
                {
                    Table.Rows.Remove(row);
                }
                
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(DeleteErrorMsg,
                                                       "Ошибка " + ex.Number,
                                                       System.Windows.Forms.MessageBoxButtons.OK,
                                                       System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message,
                                                          "Ошибка ",
                                                          System.Windows.Forms.MessageBoxButtons.OK,
                                                          System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }


            return true;
        }


        public DataRow GetRowById(int id)
        {
            var result = Table.Select(info.IdName + " = " + id.ToString());
            if (result.Count() == 0)
            {
                return null;
            }
            return result[0];
        }

        protected bool Update(int updateId, TEntity c)
        {
            SetCommandParameters(c,command.Parameters);
            command.CommandText = info.UpdateStatement;

            try
            {
                command.ExecuteNonQuery();
                DataRow row = GetRowById(updateId);
                //int index = Table.Rows.IndexOf(row);

                if (row != null)
                {
                    DataRow newRow = UploadRow(updateId);
                    for (int i = 0, count = Table.Columns.Count; i<count; i++){
                        row[i] = newRow[i];
                    }

                }

            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    System.Windows.Forms.MessageBox.Show(RepeatErrorMsg,
                                                           "Ошибка ",
                                                           System.Windows.Forms.MessageBoxButtons.OK,
                                                           System.Windows.Forms.MessageBoxIcon.Error);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(UpdateErrorMsg,
                                                           "Ошибка " + ex.Number,
                                                           System.Windows.Forms.MessageBoxButtons.OK,
                                                           System.Windows.Forms.MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message,
                                                          "Ошибка",
                                                          System.Windows.Forms.MessageBoxButtons.OK,
                                                          System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool disposed = false;

        // реализация интерфейса IDisposable.
        public void Dispose()
        {
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //queryBuilder = null;
                    info = null;
                }
                command.Dispose();
                Table.Dispose();
                disposed = true;
            }
        }

        // Деструктор
        ~Repository()
        {
            Dispose(false);
        }

    }
}
