using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class CartController : ApiController
    {
        FinalProjectEntities cartobj = new FinalProjectEntities();

        ResponseData res = new ResponseData();
        public CartController()
        {
            cartobj.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Cart
        public IEnumerable<T_Cart> Get()
        {
            return cartobj.T_Cart.ToList();
        }

        // GET: api/Cart/5
        public ResponseData Get(int id)
        {
            var CartList = cartobj.T_Cart.ToList();
            var List = (from cart in CartList
                        where cart.UserId == id
                        select cart).ToList();

            if (CartList != null)
            {
                res.Data = List;
                res.Status = "Success";
                res.Error = null;
                return res;
            }

            else
            {

                res.Status = "Fail";
                res.Error = null;
                return res;
            }

        }


        // POST: api/Cart
        [HttpPost]
        [Route("api/Cart/AddCart")]
        public void Add(T_Cart cart)
        {
            T_Cart cart1 = new T_Cart();
            cart1.Price = 150;
            cart1.UserId = cart.UserId;
            cart1.SeatId = cart.SeatId;
            cart1.Quantity = 1;
            cartobj.T_Cart.Add(cart1);
            cartobj.SaveChanges();
        
        }

        // PUT: api/Cart/5
        public void Put(int id, [FromBody] T_Cart c)
        {
            T_Cart c1 = cartobj.T_Cart.Find(id);
          
            c1.UserId = c.UserId;
            c1.SeatId = c.SeatId;
            c1.Quantity = c.Quantity;
            c1.Price = c.Price;
            cartobj.SaveChanges();
        }

        // DELETE: api/Cart/5
        public void Delete(int id)
        {
            T_Cart data = cartobj.T_Cart.Find(id);
            cartobj.T_Cart.Remove(data);
            cartobj.SaveChanges();

        }
    }
}
