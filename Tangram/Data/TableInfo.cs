using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.Data
{
    public class TableInfo
    {
        public string TableName { get; set; }
        public string IdName { get; set; }
        public string SelectStatement { get; set; }
        public string InsertStatement { get; private set; }
        public string UpdateStatement { get; private set; }
        public string DeleteStatement { get; private set; }
        public List<MySqlParameter> parameters = new List<MySqlParameter>();
        public Dictionary<string,string> linkedTables = new Dictionary<string, string>();

        public void GenerateStatements()
        {
            string insertFieldNames = "(";
            string insertValues = "";

            UpdateStatement = "update " +TableName + " set ";

            foreach (MySqlParameter parameter in parameters)
            {
                if (parameter.ParameterName == IdName) continue;
                insertFieldNames += parameter.ParameterName + ",";
                insertValues += "@" + parameter.ParameterName + ",";
                UpdateStatement += parameter.ParameterName + " = @" + parameter.ParameterName + ",";
            }

            insertFieldNames = insertFieldNames.Remove(insertFieldNames.Count() - 1, 1);
            insertFieldNames += ")";
            insertValues = insertValues.Remove(insertValues.Count() - 1, 1);

            UpdateStatement = UpdateStatement.Remove(UpdateStatement.Count() - 1, 1);
            UpdateStatement += " where " + IdName + "=@" + IdName + ";";

            InsertStatement = String.Format("insert into {0} {1} values ({2});", TableName, insertFieldNames, insertValues);

            DeleteStatement = "delete from " + TableName + " where " + IdName + "=@" + IdName;
        }

    }
}
