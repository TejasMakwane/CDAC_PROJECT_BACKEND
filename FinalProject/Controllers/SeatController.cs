using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class SeatController : ApiController
    {
        FinalProjectEntities dalobj = new FinalProjectEntities();
        ResponseData res = new ResponseData();

        public SeatController()
        {
            dalobj.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Seat
        public IEnumerable<T_Seat> Get()
        {
            return dalobj.T_Seat.ToList();
        }
        [HttpGet]
        [Route("api/Sloat")]
        public IEnumerable<T_Sloats> Get1()
        {
            return dalobj.T_Sloats.ToList();
        }

        // GET: api/Seat/5
        public T_Seat Get(int id)
        {
            return dalobj.T_Seat.Find();
        }

        // POST: api/Seat
        [HttpPost]
        [Route("api/Seat/AddSeat")]
        public ResponseData addseat([FromBody]T_Seat seat)
        {
            var result = dalobj.T_Seat.Add(seat);
            dalobj.SaveChanges();
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

        // PUT: api/Seat/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Seat/5
        public void Delete(int id)
        {
        }
    }
}
