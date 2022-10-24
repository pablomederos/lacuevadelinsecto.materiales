using Databases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.App
{
    internal class ApplicationPrueba
    {
        public ApplicationPrueba(DbFactory factory)
        {
            ConfigureDb(factory);
        }

        private void ConfigureDb(DbFactory factory)
        {
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
