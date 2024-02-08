using Microsoft.EntityFrameworkCore;
using SadeghiTest.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SadeghiTest
{
    public class SadeghiDbContext : DbContext
    {
        public SadeghiDbContext(DbContextOptions<SadeghiDbContext> options)
       : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyModel>().HasKey(m => m.Serial);

        }
        
        public DbSet<MyModel> MyModels { get; set; }
        public DbSet<DLType> DLTypes { get; set; }

    }
}
