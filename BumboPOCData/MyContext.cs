using Microsoft.EntityFrameworkCore;
using BumboData.DomainModels;

namespace BumboData
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<PrognosisDay> Prognosis { get; set; }
        public DbSet<PlannedShift> PlannedShift { get; set; }
        public DbSet<UnavailableMoment> UnavailableMoment { get; set; }
        public DbSet<WorkedShift> WorkedShift { get; set; }


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

            modelBuilder.Entity<PrognosisDay>()
                .HasIndex(p => p.Date).IsUnique(true);


            modelBuilder.Entity<PlannedShift>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.PlannedShifts);

            modelBuilder.Entity<PlannedShift>()
                .HasOne(p => p.PrognosisDay)
                .WithMany(p => p.PlannedShiftsOnDay)
                .HasForeignKey(p => p.PrognosisId);

            modelBuilder.Entity<UnavailableMoment>()
                .HasOne(u => u.Employee)
                .WithMany(e => e.UnavailableMoments)
                .HasForeignKey(u => u.EmployeeId);
            modelBuilder.Entity<WorkedShift>()
                .HasOne(w => w.Employee)
                .WithMany(e => e.WorkedShifts)
                .HasForeignKey(w => w.EmployeeId);



        }

    }
}
