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

        public string Get(int id)
        {
            return "value";
        }

        public IQueryable<User> Get(string username, string password)
        {
            UserManager userManager = new UserManager();
            var users = userManager.ValidateUser(username.Trim(), password.Trim());
            if (users.Count == 1)
                return users.AsQueryable();
            return null;
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