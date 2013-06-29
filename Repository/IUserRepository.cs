﻿using MwmsBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepository
{
    public interface IUserRepository : IRepository<User, string>
    {
        IEnumerable<User> FindUsers();
        IEnumerable<User> Find(string text);
    }
}
