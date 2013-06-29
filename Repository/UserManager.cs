using MwmsBusiness;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepository
{
    public class UserManager : NHibernateRepository<User, string>, IUserRepository
    {
        ISession _session;

        public UserManager(ISession session)
            : base(session)
        {
            _session = session;
        }

        public IList<User> FindByUserName(string username)
        {
            return _session.QueryOver<User>().Where(x => x.UserName == username).List();
        }

        public IList<User> FindByClientId(string clientId)
        {
            return _session.QueryOver<User>().Where(x => x.ClientId == clientId).List();
        }

        public void DeleteUser(User user)
        {
            _session.Delete(user);
            ExecuteUnitOfWork(_session);
        }

        public void SaveOrUpdateUser(User user)
        {
            _session.SaveOrUpdate(user);
            ExecuteUnitOfWork(_session);
        }

        public IEnumerable<User> FindUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(string text)
        {
            throw new NotImplementedException();
        }

        private void ExecuteUnitOfWork(ISession session)
        {
            NHibernateUnitOfWork unitOfWork = new NHibernateUnitOfWork(session);
            unitOfWork.SaveChanges();
        }

    }
}
