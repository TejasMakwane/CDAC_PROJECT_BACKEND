using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class TheaterController : ApiController
    {
        FinalProjectEntities thetobj = new FinalProjectEntities();
        ResponseData res = new ResponseData();

        public TheaterController()
        {
            thetobj.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Theater
        public IEnumerable<T_Theater> Get()
        {
            return thetobj.T_Theater.ToList();
        }

        // GET: api/Theater/5
        public T_Theater Get(int id)
        {
            return thetobj.T_Theater.Find(id);
        }

        // POST: api/Theater
        public void Post([FromBody]string value)
        {
        }

        [HttpPost]
        [Route("api/Theater/AddTheater")]
        public ResponseData addtheater(T_Theater theater)
        {
            var result = thetobj.T_Theater.Add(theater);
            thetobj.SaveChanges();

            if(result!=null)
            {
                res.Data = result;
                res.Status = "Success";
                res.Error = null;
                return res;
            }

            else
            {
                res.Data = result;
                res.Status = "Fail";
                res.Error = null;
                return res;
            }

        }
        // PUT: api/Theater/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Theater/5
        public void Delete(int id)
        {
            T_Theater data = thetobj.T_Theater.Find(id);
            thetobj.T_Theater.Remove(data);
            thetobj.SaveChanges();
        }
    }
}
