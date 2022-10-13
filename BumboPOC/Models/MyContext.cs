using Microsoft.EntityFrameworkCore;

namespace BumboPOC.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<PrognosisDay> Prognosis { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Employee has many departments and set keys
            modelBuilder.Entity<Employee>()
                     .HasMany(e => e.Departments)
                     .WithMany(d => d.Employees);
            modelBuilder.Entity<Departments>()
                 .HasMany(d => d.Employees)
                 .WithMany(e => e.Departments);
            







        }

    }
}
