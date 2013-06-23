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
    public class NHibernateRepository<T> : IRepository<T> where T : class
    {
        protected Configuration config;
        protected ISessionFactory sessionFactory;

        public NHibernateRepository()
        {
            config = Fluently.Configure()
                .Database(
                    MsSqlConfiguration
                    .MsSql2008
                    .ConnectionString(@"Data Source=SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateRepository<T>>())
                .BuildConfiguration();

            sessionFactory = config.BuildSessionFactory();
        }

        public void Save(T value)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(value);
                transaction.Commit();
            }
        }

        //Find one only
        //public T Find(string propertyName1, string propertyName2, string value1, string value2)
        //{
        //    using (var session = sessionFactory.OpenSession())
        //    using (var transaction = session.BeginTransaction())
        //    {
        //        return session.CreateCriteria(typeof(T)).Add(Expression.Eq(propertyName1, value1))
        //                                 .Add(Expression.Eq(propertyName2, value2)).List()[0];
        //    }
        //}

        public T Get(object id)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var res = session.Get<T>(id);
                return res;
            }
        }

        public void Update(T value)
        {
            throw new NotImplementedException();
        }

        public void Delete(T value)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
