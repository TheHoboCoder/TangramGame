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
    public abstract class Repository<TEntity>: IDisposable where TEntity:BaseEntity 
    {
        private MySqlCommand command = new MySqlCommand();
        private List<TEntity> entities;

        public IEnumerable<TEntity> Entities
        {
            get
            {
                return entities;
            }
        }
        

        private bool objectMode = false;

        public DataTable Table { get; protected set; }
        public DataView filteredTable { get; private set; }

        protected abstract TableInfo  info { get;} 

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

        public Repository(MySqlConnection connection, bool objectMode)
        {
            command.Connection = connection;
            this.objectMode = objectMode;
            if (!objectMode)
            {
                Table = new DataTable();
                filteredTable = new DataView(Table);
            }
            else
            {
                entities = new List<TEntity>();
            }

           

            RepeatErrorMsg = "Значение не должно повторяться!";
            DeleteErrorMsg = "Не удалось удалить запись!";
            UpdateErrorMsg = "Не удалось обновить запись!";
            InsertErrorMsg = "Не удалось добавить запись!";

            CheckOnDelete = true;
            //InitCommandParameters();
            
          
        }

        protected bool Upload(string condition = null)
        {
            if (Table == null) Table = new DataTable();

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

                    if (objectMode)
                    {
                        foreach(DataRow row in Table.Rows)
                        {
                            try
                            {
                                TEntity entity = MapOut(row);
                                if (entity != null)
                                {
                                    entities.Add(entity);
                                }
                            }
                            catch(Exception) { }
                           
                        }
                        Table.Clear();
                        Table.Dispose();
                        Table = null;
                    }
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

        protected void InitCommandParameters()
        {
            if (info.parameters != null)
            {
                foreach (var parameter in info.parameters)
                {
                    command.Parameters.Add(parameter);
                }
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

                if (!objectMode)
                {
                    Table.ImportRow(UploadRow(newId));
                }
                else
                {
                    c.Id = newId;
                    entities.Add(c);
                }

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

                if (!objectMode)
                {
                    DataRow row = GetRowById(deleteId);
                    if (row != null)
                    {
                        Table.Rows.Remove(row);
                    }
                }
                else
                {
                    TEntity entity = GetEntityById(deleteId);
                    if (entity != null)
                    {
                        entities.Remove(entity);
                    }
                   
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

        public TEntity GetEntityById(int id)
        {
            if (entities.Count() == 0)
            {
                return null;
            }
            else
            {
                return entities.Where(e => e.Id == id).First();
            }
            
        }

        public bool Update( TEntity c)
        {
            SetCommandParameters(c,command.Parameters);
            command.CommandText = info.UpdateStatement;

            try
            {
                command.ExecuteNonQuery();

                if (!objectMode)
                {
                    DataRow row = GetRowById(c.Id);
                    //int index = Table.Rows.IndexOf(row);

                    if (row != null)
                    {
                        DataRow newRow = UploadRow(c.Id);
                        for (int i = 0, count = Table.Columns.Count; i < count; i++)
                        {
                            row[i] = newRow[i];
                        }

                    }
                }
                else
                {
                    TEntity entity = GetEntityById(c.Id);
                    if (entity != null)
                    {
                        entity = c;
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
                }
                command.Dispose();
                if(Table!=null) Table.Dispose();
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
