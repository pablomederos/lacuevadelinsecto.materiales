﻿using Databases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.Componentes.Environments.Testing
{
    public class TestMongoContext : DBMongoContext
    {
        public override void CreateConnection()
        {
            //ConfigureDomain();

            ConfigureConnection("String de conexión de testing");

            Console.WriteLine($"Se creó conexión MongoDb de testing: {IsConnected}");
        }

        //private void ConfigureDomain() { }
    }
}