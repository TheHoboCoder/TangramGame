using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.Data
{
    class DatabaseHelper
    {
        protected MySqlConnection connection;

        public DatabaseHelper(MySqlConnection connection)
        {
            this.connection = connection;
        }
    }
}
