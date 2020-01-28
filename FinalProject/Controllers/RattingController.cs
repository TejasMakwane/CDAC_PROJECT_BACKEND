using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class RattingController : ApiController
    {
        FinalProjectEntities ratobj = new FinalProjectEntities();
        ResponseData res = new ResponseData();

        public RattingController()
        {
            ratobj.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Ratting
        public IEnumerable<T_Ratting> Get()
        {
            return ratobj.T_Ratting.ToList();
        }

        // GET: api/Ratting/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ratting
        [HttpPost]
        [Route("api/Ratting/AddRate")]
        public ResponseData addrating([FromBody]T_Ratting rate)
        {
            T_Ratting rate1 = new T_Ratting();
            rate1.UserId = rate.UserId;
            rate1.MovieId = 6000;
            rate1.Rating = rate.Rating;
            rate1.Comment = rate.Comment;
            ratobj.T_Ratting.Add(rate1);
            

            try
            {
                ratobj.SaveChanges();
                res.Data = rate1;
                res.Status = "Success";
                res.Error = null;
                return res;
            }
            catch (Exception ex)
            {
                res.Error = ex;
                return res;
            }
            //if (result != null)
            //{
            //    res.Data = result;
            //    res.Status = "Success";
            //    res.Error = null;
            //    return res;
            //}

            //else
            //{
            //    res.Data = result;
            //    res.Status = "Fail";
            //    res.Error = null;
            //    return res;
            //}
        }


        // PUT: api/Ratting/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ratting/5
        public void Delete(int id)
        {
        }
    }
}
