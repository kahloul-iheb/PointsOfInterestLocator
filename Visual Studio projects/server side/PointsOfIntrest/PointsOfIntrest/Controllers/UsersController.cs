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
    public class UsersController : ApiController
    {
        private UserDBContext db = new UserDBContext();

        // GET api/Users
        public IEnumerable<User> GetUsers()
        {
            return db.Users.AsEnumerable();
        }

        // GET api/Users/5
        public User GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                //GetUser(id);
            }

            return user;
        }
        public User GetUser(string UserName)
        {
            User user=null;
            if (db.Users.Where((p) => p.UserName.ToLower() == UserName.ToLower()).Count()>0)
            {
                user = db.Users.Where((p) => p.UserName.ToLower()==UserName.ToLower()).First<User>();
                return user;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            

            
        }
        // PUT api/Users/5
        public HttpResponseMessage PutUser(int id, User user)
        {
            if (ModelState.IsValid && id == user.ID)
            {
                db.Entry(user).State = EntityState.Modified;

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
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Users
        public HttpResponseMessage PostUser(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Users/5
        public HttpResponseMessage DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Users.Remove(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}