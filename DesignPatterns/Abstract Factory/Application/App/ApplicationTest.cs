using LaCuevaDelInsecto.Databases.Base;

namespace LaCuevaDelInsecto.Application.App
{
    internal class ApplicationTest
    {
        public ApplicationTest(IDbFactory factory)
        {
            ConfigureDb(factory);
        }

        // La instancia puede crearse in situ, y no es obligatorio
        // utilizar un argumento.
        // Esto es solo un ejemplo.
        private static void ConfigureDb(IDbFactory factory)
        {

            // No es necesario usar las superclases, pero promueve el desacoplamiento
            // y mayor resiliencia del software.
            DBMongoContext dBMongoContext = factory.CreateMongoContext();

            dBMongoContext.CreateConnection();
            dBMongoContext.CloseConnection();




            DBSQLContext dBSQLContext = factory.CreateSQLContext();

            dBSQLContext.CreateConnection();
            dBSQLContext.CloseConnection();



            DBRedisContext dBRedisContext = factory.CreateRedisContext();

            dBRedisContext.CreateConnection();
            dBRedisContext.CloseConnection();
        }
    }
}
