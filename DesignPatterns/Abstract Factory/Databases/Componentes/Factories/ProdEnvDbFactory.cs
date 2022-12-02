using LaCuevaDelInsecto.Databases.Base;
using LaCuevaDelInsecto.Databases.Componentes.Environments.Production;

namespace LaCuevaDelInsecto.Databases.Componentes.Factories
{
    public class ProdEnvDbFactory : IDbFactory
    {
        public DBMongoContext CreateMongoContext() => new ProdMongoContext();

        public DBRedisContext CreateRedisContext() => new ProdRedisContext();

        public DBSQLContext CreateSQLContext() => new ProdSQLContext();
    }
}
