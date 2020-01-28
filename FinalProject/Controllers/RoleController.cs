using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class RoleController : ApiController
    {
        FinalProjectEntities dalobj = new FinalProjectEntities();

        public RoleController()
        {
            dalobj.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Role
        public IEnumerable<T_Roles> Get()
        {
            return (dalobj.T_Roles.ToList());
        }

        // GET: api/Role/5
        public T_Roles Get(int id)
        {
            return (dalobj.T_Roles.Find(id));
        }

        // POST: api/Role
        public void Post([FromBody]T_Roles rol)
        {
            dalobj.proc_AddRole(rol.RoleName);
           

        }

        // PUT: api/Role/5
        public void Put(int id, [FromBody]T_Roles rol)
        {
            dalobj.proc_ModifyRole(id, rol.RoleName);

        }

        // DELETE: api/Role/5
        public void Delete(int id)
        {
            dalobj.proc_RemoveRole(id);
        }
    }
}
