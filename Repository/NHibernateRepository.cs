using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MwmsBusiness;
using MwmsBusiness.Mapping;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
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

        //Server=db2165ad-7d0c-46e3-b7f6-a1fb008efbb5.sqlserver.sequelizer.com;Database=dbdb2165ad7d0c46e3b7f6a1fb008efbb5;User ID=aqnkgphwauowrnei;Password=uCK4nFVdiXDyMdqkedzbCL48HZnmm2ctaBEZokFBZAoyf3o6FxWLgjYRHLuusJZq;
        //Data Source=rberana;Initial Catalog=mwms;Integrated Security=True;User ID=sa;Password=sql
        public NHibernateRepository()
        {
            try
            {
                config = Fluently.Configure()
                          .Database(
                              MsSqlConfiguration
                              .MsSql2008
                              .ConnectionString("Data Source=rberana;Initial Catalog=mwms;Integrated Security=True;User ID=sa;Password=sql"))
                              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TEntity>())
                              .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
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
