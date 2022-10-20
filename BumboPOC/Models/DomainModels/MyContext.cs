using Microsoft.EntityFrameworkCore;

namespace BumboPOC.Models.DatabaseModels
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<PrognosisDay> Prognosis { get; set; }
        public DbSet<PlannedShift> PlannedShift { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Employee has many departments and set keys
            modelBuilder.Entity<Employee>()
                     .HasMany(e => e.Departments)
                     .WithMany(d => d.Employees);
            modelBuilder.Entity<Departments>()
                 .HasMany(d => d.Employees)
                 .WithMany(e => e.Departments);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.PlannedShifts)
                .WithOne(p => p.Employee);


            modelBuilder.Entity<PlannedShift>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.PlannedShifts);

            modelBuilder.Entity<PlannedShift>()
                .HasOne(p => p.PrognosisDay)
                .WithMany(p => p.PlannedShifts);





        }

    }
}
