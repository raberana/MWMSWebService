using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MwmsBusiness;
using MwmsBusiness.Mapping;
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

        //Server=ff4c7673-21c8-4089-93c4-a1e500291e65.sqlserver.sequelizer.com;Database=dbff4c767321c8408993c4a1e500291e65;User ID=dinbhyfbgnktskik;Password=gWQ2FQgQJVudrdeh3LFDvqysvcPgvYiXpFDmiwBzmYCEKjTmAqZgZXdYwwEDbauS;
        //Data Source=localhost;Initial Catalog=mwms;Integrated Security=True;User ID=sa;Password=sql
        public NHibernateRepository()
        {
            try
            {
                config = Fluently.Configure()
                          .Database(
                              MsSqlConfiguration
                              .MsSql2008
                              .ConnectionString("Server=ff4c7673-21c8-4089-93c4-a1e500291e65.sqlserver.sequelizer.com;Database=dbff4c767321c8408993c4a1e500291e65;User ID=dinbhyfbgnktskik;Password=gWQ2FQgQJVudrdeh3LFDvqysvcPgvYiXpFDmiwBzmYCEKjTmAqZgZXdYwwEDbauS"))
                              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TEntity>())
                          .BuildConfiguration();

                sessionFactory = config.BuildSessionFactory();
                if (_session == null)
                    _session = sessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        protected ISession Session
        {
            get
            {
                return _session;
            }
        }

        public TEntity GetById(string id)
        {
            return _session.Get<TEntity>(id);
        }

        public void Create(TEntity entity)
        {
            NHibernateUnitOfWork unitOfWork = new NHibernateUnitOfWork(_session);
            unitOfWork.Session.SaveOrUpdate(entity);
            unitOfWork.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            NHibernateUnitOfWork unitOfWork = new NHibernateUnitOfWork(_session);
            unitOfWork.Session.SaveOrUpdate(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            NHibernateUnitOfWork unitOfWork = new NHibernateUnitOfWork(_session);
            unitOfWork.Session.Delete(entity);
            unitOfWork.SaveChanges();
        }


    }
}
