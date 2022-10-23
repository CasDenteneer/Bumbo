using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BumboPOC.Models.DomainModels
{
    public class MySeedData
    {
        public static async Task SeedAsync(MyContext context)
        {
            if (!context.Employees.Any())
            {
                //adding employees for testing
                context.Employees.AddRange(
                    new Employee
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        BirthDate = new DateTime(1990, 1, 1),
                        Email = "johndoe@gmail.com",
                        Active = true,
                        BankNumber = "12-4567-89"
                    },
                    new Employee
                    {
                        FirstName = "Hans",
                        LastName = "Zimmer",
                        BirthDate = new DateTime(2000, 4, 20),
                        Email = "hanszimmer@myspace.home",
                        Active = true,
                        BankNumber = "93-9116-90"
                    },
                    new Employee
                    {
                        FirstName = "Joe",
                        LastName = "Biden",
                        BirthDate = new DateTime(1970, 9, 11),
                        Email = "joebidon@dk.anymore.us",
                        Active = true,
                        BankNumber = "42-4505-90"
                    }
                );
            }
            if (!context.PlannedShift.Any())
            {
                //adding shifts for every employee as testdata
                var employees = context.Employees.ToList();
                foreach (var employee in employees)
                {
                    Random random = new Random();
                    int _day1 = random.Next(1, 8);
                    int _day2 = random.Next(1, 8);
                    int _day3 = random.Next(1, 8);
                    int _day4 = random.Next(1, 8);
                    context.PlannedShift.AddRange(
                        new PlannedShift
                        {
                            EmployeeId = employee.Id,
                            PrognosisId = 1,
                            StartTime = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, _day1, 8, 0, 0),
                            EndTime = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, _day1, 16, 0, 0),
                            Department = DepartmentEnum.Cassiere,
                            Location = "Den Bosch"
                        },
                        new PlannedShift
                        {
                            EmployeeId = employee.Id,
                            PrognosisId = 1,
                            StartTime = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, _day2, 13, 0, 0),
                            EndTime = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, _day2, 17, 0, 0),
                            Department = DepartmentEnum.Cassiere,
                            Location = "Den Bosch"
                        },
                        new PlannedShift
                        {
                            EmployeeId = employee.Id,
                            PrognosisId = 1,
                            StartTime = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, _day3, 18, 0, 0),
                            EndTime = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, _day3, 21, 0, 0),
                            Department = DepartmentEnum.Fresh,
                            Location = "Den Bosch"
                        },
                        new PlannedShift
                        {
                            EmployeeId = employee.Id,
                            PrognosisId = 1,
                            StartTime = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, _day4, 9, 0, 0),
                            EndTime = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, _day4, 12, 0, 0),
                            Department = DepartmentEnum.Stocker,
                            Location = "Tilburg"
                        }
                 );
                }

            }
            if (!context.Prognosis.Any())
            {
                context.Prognosis.AddRange(
                    new PrognosisDay
                    {
                        AmountOfCollies = 123,
                        AmountOfCustomers = 79,
                        Date = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day),
                        CassiereDepartment = 21.0,
                        FreshDepartment = 34.0,
                        StockersDepartment = 16.0
                    }
                );
            }
            await context.SaveChangesAsync();
        }
    }
}
