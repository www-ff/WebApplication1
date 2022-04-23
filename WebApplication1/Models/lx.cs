using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class lx:DbContext
    {
        public lx():base("name=lx") { }
        public DbSet<student> student { get; set; }
    }
}