﻿using MwmsBusiness;
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

        public IList<User> FindUserByUserName(string username)
        {
            return Session.QueryOver<User>().Where(x => x.UserName == username).List();
        }

        public IList<User> FindUserByClientId(string clientId)
        {
            return Session.QueryOver<User>().Where(x => x.ClientId == clientId).List();
        }

        public IList<User> FindUserById(int id)
        {
            return Session.QueryOver<User>().Where(x => x.Id == id).List();
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

        public IList<User> ValidateUser(string userName, string password)
        {
            var users = Session.QueryOver<User>().Where(x => x.UserName == userName.Trim() && x.Password == password.Trim()).List();
            return users;
        }

    }
}
