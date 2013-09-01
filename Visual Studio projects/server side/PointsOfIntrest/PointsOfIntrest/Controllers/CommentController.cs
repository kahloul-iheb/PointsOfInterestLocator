using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using PointsOfIntrestAPI.Models;
namespace PointsOfIntrest.Controllers
{
    public class CommentController : ApiController
    {
        private UserDBContext db = new UserDBContext();
        // GET api/comment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/comment/5
        public string Get(int id)
        {
            return "value";
        }

        // GET api/comment/5
        public IEnumerable<Comment> Get(string place)
        {
            /*List<Comment> com = new List<Comment>();
            foreach (User user in db.Users.ToList())
            {
                if (user.Comments!=null)
                {
                    com.AddRange(user.Comments.Where(
                    (p) => p.Place.ToLower() == place.ToLower()));   
                }
                    
            }
            return com;
             */
            return db.Comments.Where((p) => p.Place.ToLower() == place.ToLower());
        }


        // POST api/comment
        public HttpResponseMessage Post(Comment comment)
        {
            //User u = db.Users.Where(
                    //(p) => p.UserName.ToLower() == comment.UserName.ToLower()).First<User>();
            //db.Users.Remove(u);
            
            //u.addComment(comment);
            //db.Entry(u).State = EntityState.Modified;
            //db.Users.Add(u);
            db.Comments.Add(comment);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage PostUser(string id, string place, string body)
        {
            User u = db.Users.Where(
                (p) => p.UserName.ToLower() == id.ToLower()).First<User>();
            u.addComment(place, body);
            db.Entry(u).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // PUT api/comment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/comment/5
        public void Delete(int id)
        {
        }
    }
}
