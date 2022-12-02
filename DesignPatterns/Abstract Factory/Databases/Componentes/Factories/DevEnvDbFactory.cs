using LaCuevaDelInsecto.Databases.Base;
using LaCuevaDelInsecto.Databases.Componentes.Environments.Develop;

namespace LaCuevaDelInsecto.Databases.Componentes.Factories
{
    public class DevEnvDbFactory : IDbFactory
    {
        public DBMongoContext CreateMongoContext() => new DevMongoContext();

        public DBRedisContext CreateRedisContext() => new DevRedisContext();

        public DBSQLContext CreateSQLContext() => new DevSQLContext();
    }
}
