

namespace LaCuevaDelInsecto.Databases.Base
{
    public abstract class DBRedisContext
    {
        public bool IsConnected { get; private set; }

        public abstract void CreateConnection();

        public void CloseConnection()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cerrando conexión");

            IsConnected = false;
        }

        protected void ConfigureConnection(string connectionString)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Conectado a Redis usando los datos: {connectionString}");

            IsConnected = true;
        }
    }
}
