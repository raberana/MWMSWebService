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
        public UserManager()
            : base()
        {
        }

        public User FindUserByUserName(string username)
        {
            return Session.QueryOver<User>().Where(x => x.UserName == username).SingleOrDefault();
        }

        public User FindUserByClientId(string clientId)
        {
            return Session.QueryOver<User>().Where(x => x.ClientId == clientId).SingleOrDefault();
        }

        public User FindUserById(int id)
        {
            return Session.QueryOver<User>().Where(x => x.Id == id).SingleOrDefault();
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public void SaveOrUpdateUser(User user)
        {
            Update(user);
        }

        public void AddUser(string userName, string password, string clientId, string clientName)
        {
            User user = new User()
            {
                UserName = userName,
                Password = password,
                ClientId = clientId,
                ClientName = clientName
            };
            Create(user);
        }

        public IEnumerable<User> FindUsers()
        {
            return Session.QueryOver<User>().Where(user => user.ClientId != "").List().AsEnumerable();
        }

        public IEnumerable<User> Find(string text)
        {
            throw new NotImplementedException();
        }

        public User ValidateUser(string userName, string password)
        {
            return Session.QueryOver<User>()
                .Where(x => x.UserName == userName.Trim() && x.Password == password.Trim())
                .SingleOrDefault();
        }

    }
}
