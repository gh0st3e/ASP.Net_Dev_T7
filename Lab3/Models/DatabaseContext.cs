using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DBContext")
        { }

        public DbSet<Student> Students { get; set; }
    }
}