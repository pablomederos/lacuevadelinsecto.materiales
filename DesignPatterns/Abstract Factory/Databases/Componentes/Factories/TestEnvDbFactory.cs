using LaCuevaDelInsecto.Databases.Base;
using LaCuevaDelInsecto.Databases.Componentes.Environments.Testing;

namespace LaCuevaDelInsecto.Databases.Componentes.Factories
{
    public class TestEnvDbFactory : IDbFactory
    {
        public DBMongoContext CreateMongoContext() => new TestMongoContext();

        public DBRedisContext CreateRedisContext() => new TestRedisContext();

        public DBSQLContext CreateSQLContext() => new TestSQLContext();
    }
}
