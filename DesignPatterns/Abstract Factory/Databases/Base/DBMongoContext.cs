
namespace Databases.Base
{
    public abstract class DBMongoContext
    {
        public bool IsConnected { get; private set; }

        public abstract void CreateConnection();

        public void CloseConnection()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cerrando conexión");

            IsConnected = false;
        }

        protected void ConfigureConnection(string connectionString)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Conectado a MongoDb usando los datos {connectionString}");

            IsConnected = true;
        }
    }
}
