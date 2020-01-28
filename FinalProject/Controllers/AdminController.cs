using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class AdminController : ApiController
    {
        FinalProjectEntities adminobj = new FinalProjectEntities();

        public AdminController()
        {
            adminobj.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Admin
        [Route("api/Admin/UserList")]
        public IEnumerable<T_Users> Get()
        {
            return (adminobj.T_Users.ToList());
        }

        // GET: api/Admin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admin
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
            T_Users data = adminobj.T_Users.Find(id);
            adminobj.T_Users.Remove(data);
            adminobj.SaveChanges();
        }
    }
}
