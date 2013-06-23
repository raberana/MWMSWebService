using MwmsBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepository
{
    public class UserManager
    {
        public User GetUser(int id)
        {
            var repository = new NHibernateRepository<User>();
            var user = repository.Get(id);
            return user;
        }

        public void SaveUser(User user)
        {
            var repository = new NHibernateRepository<User>();
            repository.Save(user);
        }
    }
}
