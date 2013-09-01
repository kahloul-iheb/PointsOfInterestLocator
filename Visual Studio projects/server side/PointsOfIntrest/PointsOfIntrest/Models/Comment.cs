using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PointsOfIntrestAPI.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Place { get; set; }
        public string Body { get; set; }

    }
    public class CommentDBContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
    }
}
