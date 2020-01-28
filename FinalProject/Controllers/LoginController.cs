using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class LoginController : ApiController
    {
        FinalProjectEntities logdalobj = new FinalProjectEntities();
        T_Users user = new T_Users();

        public LoginController()
        {
            logdalobj.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Login
        [Route("api/Login/PassHistory")]
        public IEnumerable<T_PasswordHistoryLog> Get_data()
        {
            return (logdalobj.T_PasswordHistoryLog.ToList());
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        [Route("api/Login")]
        public ResponseData Post([FromBody] T_Users u)
        {
            ResponseData response = new ResponseData();
            if (u.EmailId != null && u.Password != null)
            {
                var ListUser = logdalobj.T_Users.ToList();
                T_Users ValidUser = (from user in ListUser
                                     where user.EmailId == u.EmailId &&
                                     user.Password == u.Password
                                     select user).SingleOrDefault();

                if (ValidUser != null)
                {
                    response.Data = ValidUser;
                    response.Error = null;
                    response.Status = "Success";
                    return response;
                }
                else
                {
                    response.Error = null;
                    response.Status = "Incorrect Credential";
                    return response;
                }
            }
            else
            {
                response.Error = null;
                response.Status = "Field are Empty";
                return response;
            }

        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
