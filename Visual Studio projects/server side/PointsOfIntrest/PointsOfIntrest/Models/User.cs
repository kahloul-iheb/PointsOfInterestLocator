
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PointsOfIntrestAPI.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Comment> Comments { get; set; }
        private int IDC = 0;

        public void addComment(string place, string body)
        {
            if (IDC== 0)
            {
                Comments = new List<Comment>();
            }
            Comments.Add(new Comment { UserName=UserName ,Place = place, Body = body });
            IDC++;
        }
        public void addComment(Comment comment)
        {
            if (IDC == 0)
            {
                Comments = new List<Comment>();
            }
            Comments.Add(comment);
            IDC++;
        }
        public Boolean deleteComment()
        {
            if (IDC > 0)
            {
                Comments.RemoveAt(IDC);
                IDC--;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
