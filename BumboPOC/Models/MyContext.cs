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
            // Employee has many departments
            modelBuilder.Entity<Employee>()
                     .HasMany(e => e.Departments)
                     .WithMany(e => e.Employees);
            modelBuilder.Entity<Departments>().HasKey(e => new { e.EmployeeId, e.Department });
        }

    }
}
