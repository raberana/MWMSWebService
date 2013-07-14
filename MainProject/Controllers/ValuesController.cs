using MwmsBusiness;
using ProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainProject.Controllers
{

    public class ValuesController : ApiController
    {
        public IQueryable<User> Get()
        {
            UserManager userManager = new UserManager();
            var users = userManager.FindUsers();

            return users.AsQueryable();
        }

        public User Get(int id)
        {
            UserManager userManager = new UserManager();
            var users = userManager.FindUserById(id);

            return users[0];
        }

        public User GetValidatedUser(string username, string password)
        {
            UserManager userManager = new UserManager();
            var users = userManager.ValidateUser(username.Trim(), password.Trim());
            return users[0];
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }

        public string OptionsXXX()
        {
            return null; // HTTP 200 response with empty body
        }

    }

}