using Microsoft.EntityFrameworkCore;
using News.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.Infra.Data
{
   public  class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
    }
}
