using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MainProject
{
    public class Migrator
    {
        string connectionString;

        public Migrator(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public int Timeout { get; set; }


            public string ProviderSwitches
            {
                get { throw new NotImplementedException(); }
            }
        }

        public void Migrate(Action<IMigrationRunner> runnerAction)
        {
            try
            {
                var options = new MigrationOptions { PreviewOnly = false, Timeout = 0 };
                var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2008ProcessorFactory();
                var assembly = Assembly.GetExecutingAssembly();


                var announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));
                var migrationContext = new RunnerContext(announcer); ;
                var processor = factory.Create(this.connectionString, announcer, options);
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                runnerAction(runner);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}