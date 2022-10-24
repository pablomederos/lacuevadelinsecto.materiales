using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.Base
{
    public abstract class DBSQLContext
    {
        public bool IsConnected { get; private set; }

        public abstract void CreateConnection();

        public void CloseConnection()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cerrando conexión");

            IsConnected = false;
        }

        protected void ConfigureConnection(string connectionString)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Conectado a SQL usando los datos {connectionString}");

            IsConnected = true;
        }
    }
}
