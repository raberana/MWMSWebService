using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepository
{

    public class NHibernateRepository<TEntity, TKey> where TEntity : class
    {
        ISession _session;
        protected Configuration config;
        protected ISessionFactory sessionFactory;

        public NHibernateRepository()
        {
            config = Fluently.Configure()
                .Database(
                    MsSqlConfiguration
                    .MsSql2008
                    .ConnectionString(@"Data Source=SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateRepository<TEntity, TKey>>())
                .BuildConfiguration();

            sessionFactory = config.BuildSessionFactory();
            if (_session == null)
                _session = sessionFactory.OpenSession();
        }


        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        protected ISession Session { get { return _session; } }

        public TEntity GetById(string id)
        {
            return _session.Get<TEntity>(id);
        }

        public void Create(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public void Update(TEntity entity)
        {
            _session.SaveOrUpdate(entity);

        }

        public void Delete(TEntity entity)
        {
            _session.Delete(entity);
        }
    }
}
