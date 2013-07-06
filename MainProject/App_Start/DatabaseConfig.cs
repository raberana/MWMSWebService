using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainProject
{
    public class DatabaseConfig
    {
        public static void MigrateDatabase(string connectionString)
        {
            var migrator = new Migrator(connectionString);

            migrator.Migrate(runner => runner.MigrateUp());
        }
    }
}