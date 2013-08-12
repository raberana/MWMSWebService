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
        
        public HttpResponseMessage GetUsers()
        {
            UserManager userManager = new UserManager();
            var users = userManager.FindUsers();
            if (users != null)
                return Request.CreateResponse(HttpStatusCode.OK, users);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No users found");
        }

        public HttpResponseMessage GetUser(int id)
        {
            UserManager userManager = new UserManager();
            var user = userManager.FindUserById(id);

            if (user != null)
                return Request.CreateResponse(HttpStatusCode.OK, user);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No user found");
        }

        [AcceptVerbs("GET", "POST")]
        public HttpResponseMessage GetValidatedUser(LoginUser loginUser)
        {
            UserManager userManager = new UserManager();
            try
            {
                var savedUser = userManager.ValidateUser(loginUser.UserName.Trim(), loginUser.Password.Trim());
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Accepted, loginUser);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [AcceptVerbs("GET", "POST")]
        public HttpResponseMessage AddUser(User user)
        {
            UserManager userManager = new UserManager();
            try
            {
                userManager.Create(user);

                var savedUser = userManager.FindUserByClientId(user.ClientId);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApiWithAction", new { id = savedUser.Id }));
                return response;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

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