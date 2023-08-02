using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test.Models;
namespace test.Data
{
        public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person1> Person1 { get; set; } = default!;

         public DbSet<Cusmer> Cusmer { get; set; } = default!;
    }
}


