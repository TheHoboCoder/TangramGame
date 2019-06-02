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
        protected MySqlCommand command = new MySqlCommand();
        private List<TEntity> entities;

        //Начинает транзакцию.
        public void StartTransaction(MySqlTransaction transaction)
        {
            command.Transaction = transaction;
        }


        //Завершает транзакцию.
        public void EndTransacation()
        {
            command.Transaction.Dispose();
            command.Transaction = null;
        }

        //Автоматическое обновление таблицы
        protected bool AutoUpload { get; set; }
        //id последней добавленной или измененной записи
        private int LastId;

        //список  операций
        private enum OPERATIONS {
            UPDATE,
            INSERT,
            DELETE,
            NONE
        }

        //последняя выполненная операции
        private OPERATIONS lastOperation = OPERATIONS.NONE;

        //Список объектов данных
        public IEnumerable<TEntity> Entities
        {
            get
            {
                return entities;
            }
        }

        //режим работы класса, если object mode = true,
        //то данные из таблицы базы данных при загрузке будут сконвертированы в список объектов entities
        private bool objectMode = false;

        //таблица с данными
        public DataTable Table { get; protected set; }
        //объект DataView для фильтрации таблицы
        //позволит фильровать таблицу без обращения к базе данных
        public DataView filteredTable { get; private set; }
        

        //данные о таблице базы данных
        protected abstract TableInfo  info { get;} 

        //Сообщение при повторениии записи
        public string RepeatErrorMsg { get; set; }
        //Сообщение ошибки при изменении
        public string UpdateErrorMsg { get; set; }
        //Сообщение ошибки при удалении
        public string DeleteErrorMsg { get; set; }
        //Сообщение ошибки при добавлении
        public string InsertErrorMsg { get; set; }

        //Сообщение при удалении, если данная запись используется в другой таблице
        protected virtual string linkedErrorMsg(string table)
        {
            return "Данная запись уже используется в таблице \"" + table + "\"!";
        }

        //Включена ли проверка при удалении
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
            AutoUpload = true;
            //InitCommandParameters();
            
          
        }

        //Загружает информацию в таблицу, используя условие отбора строк condition.
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
                            //try
                            //{
                                TEntity entity = MapOut(row);
                                if (entity != null)
                                {
                                    entities.Add(entity);
                                }
                            //}
                            //catch(Exception) { }
                           
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


        //Инициализирует список параметров объекта MySqlCommand.
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

        //Устанавливает значения параметров, используя объект данных c.
        protected abstract void SetCommandParameters(TEntity c,MySqlParameterCollection parameters);
        //Создает объект данных из строки DataRow.
        public abstract TEntity MapOut(DataRow row);

        //Загружает строку из таблицы базы данных по идентификатору записи
        private DataRow UploadRow(int id)
        {
            using (DataTable dt = new DataTable())
            {
                command.CommandText = info.SelectStatement + " where " + info.TableName+"."+info.IdName + "= '" + id + "'";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    command.ExecuteNonQuery();
                    adapter.Fill(dt);
                    return dt.Rows[0];
                }
            }
        }


        //Обновляет данные в таблице, в соответствии с последней выполненной операцией (добавление, 
        public void UpdateTable()
        {
            switch (lastOperation) {
                case OPERATIONS.UPDATE:
                    DataRow row = GetRowById(LastId);

                    if (row != null)
                    {
                        DataRow newRow = UploadRow(LastId);
                        for (int i = 0, count = Table.Columns.Count; i < count; i++)
                        {
                            row[i] = newRow[i];
                        }

                    }
                    break;
                case OPERATIONS.INSERT:
                    Table.ImportRow(UploadRow(LastId));
                    break;
                case OPERATIONS.DELETE:
                    DataRow deleteRow = GetRowById(LastId);
                    if (deleteRow != null)
                    {
                        Table.Rows.Remove(deleteRow);
                    }
                    break;
                case OPERATIONS.NONE:
                    return;
            }

            lastOperation = OPERATIONS.NONE;
        }


        //Добавляет запись в таблицу базы данных.
        public int Add(TEntity c)
        {
            SetCommandParameters(c,command.Parameters);
            command.CommandText = info.InsertStatement;

            try
            {
                command.ExecuteNonQuery();
                LastId = (int)command.LastInsertedId;

                if (!objectMode)
                {
                    lastOperation = OPERATIONS.INSERT;
                    if (AutoUpload)
                    {

                        UpdateTable();
                    }
                   
                }
                else
                {
                    c.Id = LastId;
                    entities.Add(c);
                }

                return LastId;
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
                    System.Windows.Forms.MessageBox.Show(InsertErrorMsg  + ex.ToString(),
                                                           "Ошибка " + ex.Number,
                                                           System.Windows.Forms.MessageBoxButtons.OK,
                                                           System.Windows.Forms.MessageBoxIcon.Error);
                }
                return -1;
            }

        }


        //Удаляет запись по идентификатору записи.
        public bool Delete(int deleteId)
        {
            try
            {
                command.Parameters[info.IdName].Value = deleteId;
                

                if (_checkOnDelete)
                {
                    foreach (var table in info.linkedTables)
                    {
                        command.CommandText = String.Format("Select count(*) from {0} where {1} = @{1}", table.Key, info.IdName);
                        Object c = command.ExecuteScalar();
                        if (c == null) continue;
                        int rowCount = Convert.ToInt32(c);
                        if (rowCount > 0)
                        {
                            System.Windows.Forms.MessageBox.Show(linkedErrorMsg(table.Value),
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
                    LastId = deleteId;
                    lastOperation = OPERATIONS.DELETE;
                    if (AutoUpload)
                    {
                        UpdateTable();
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

        //Возвращает строку таблицы по идентификатору.
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
        //Обновляет запись в таблице базы данных.
        public bool Update( TEntity c)
        {
            SetCommandParameters(c,command.Parameters);
            command.CommandText = info.UpdateStatement;

            try
            {
                command.ExecuteNonQuery();

                if (!objectMode)
                {
                    LastId = c.Id;
                    lastOperation = OPERATIONS.UPDATE;
                    if (AutoUpload)
                    {
                        UpdateTable();
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
