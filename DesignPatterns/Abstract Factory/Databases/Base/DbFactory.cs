

namespace LaCuevaDelInsecto.Databases.Base
{
    public interface IDbFactory
    {
        DBMongoContext CreateMongoContext();
        DBRedisContext CreateRedisContext();    
        DBSQLContext CreateSQLContext();
    }
}
