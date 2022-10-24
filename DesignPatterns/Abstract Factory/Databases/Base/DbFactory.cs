using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.Base
{
    public interface DbFactory
    {
        DBMongoContext CreateMongoContext();
        DBRedisContext CreateRedisContext();    
        DBSQLContext CreateSQLContext();
    }
}
