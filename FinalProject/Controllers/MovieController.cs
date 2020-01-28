using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class MovieController : ApiController
    {
        FinalProjectEntities movieobj = new FinalProjectEntities();

        ResponseData res = new ResponseData();

        public MovieController()
        {
            movieobj.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Movie
        public IEnumerable<T_Movie> Get()
        {
            return movieobj.T_Movie.ToList();
        }

        // GET: api/Movie/5
        public ResponseData Get(int id)
        {
            var MovieList = movieobj.T_Movie.ToList();
            var List = (from movie in MovieList
                        where movie.MovieId == id
                        select movie).ToList();

            if (MovieList != null)
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

       

        // POST: api/Movie
        public ResponseData addmovie([FromBody]dynamic movie)
        {   
            T_Movie movie1 = new T_Movie();
            movie1.Title = movie.Title;
            movie1.Director = movie.Director;
            movie1.Movie_Category = movie.Movie_Category;
            movie1.Cast = movie.Cast;
            movie1.Description = movie.Description;
            movie1.Duration = DateTime.Now;
            movie1.Language = movie.Language;
            movieobj.T_Movie.Add(movie1);

            try
            {
                movieobj.SaveChanges();
                res.Data = movie1;
                res.Error = null;
                res.Status = "Success";
                return res;
            }
            catch (Exception ex)
            {
                res.Error = ex;
                return res;

            }





            //movieobj.T_Movie.Add(movie);
            //movieobj.SaveChanges();

        }




        // PUT: api/Movie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movie/5
        public ResponseData Delete(int id)
        {
           
            movieobj.T_Movie.Remove(movieobj.T_Movie.Find(id));
            movieobj.SaveChanges();
            res.Error = null;
            res.Status = "Success";
            return res;




           

           
        }
    }
}
