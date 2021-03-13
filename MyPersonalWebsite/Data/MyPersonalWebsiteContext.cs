using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPersonalWebsite.Models;

namespace MyPersonalWebsite.Data
{
    public class MyPersonalWebsiteContext : DbContext
    {
        public MyPersonalWebsiteContext (DbContextOptions<MyPersonalWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<MyPersonalWebsite.Models.Project> Project { get; set; }
    }
}
