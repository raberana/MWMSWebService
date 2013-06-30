using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepository
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public ISession Session { get { return _session; } }

        public NHibernateUnitOfWork(ISession session)
        {
            if (_session == null)
                _session = session;
            _transaction = _session.BeginTransaction();
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Rollback();
        }

        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException("UnitOfWork have already been saved.");

            _transaction.Commit();
            _transaction = null;
        }
    }
}
