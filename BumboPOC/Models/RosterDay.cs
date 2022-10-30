using BumboPOC.Models.DomainModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel;
using System.Drawing;
using System.Numerics;

namespace BumboPOC.Models
{
    public class RosterDay
    {
        // not a database model, used for the roster view

        // reference to date, get from prognosisday
        public DateTime Date
        {
            get { return PrognosisDay.Date; }
            set { PrognosisDay.Date = value; }
        }

        // this is the prognosis calculated by the norm but instead it is updated to the number of planned shifts on that day.
        [DisplayName("Kassa Afdeling")]
        public double? UpdatedCassiereDepartment => Math.Round((double)(PrognosisDay.CassiereDepartment - this.UpdatePrognosisWithoutPlannedHours(DepartmentEnum.Cassiere)), 2);
        [DisplayName("Vers Afdeling")]
        public double? UpdatedFreshDepartment => Math.Round((double)(PrognosisDay.FreshDepartment - this.UpdatePrognosisWithoutPlannedHours(DepartmentEnum.Fresh)), 2);
        [DisplayName("VakkenVullers Afdeling")]
        public double? UpdatedStockersDepartment => Math.Round((double)(PrognosisDay.StockersDepartment - UpdatePrognosisWithoutPlannedHours(DepartmentEnum.Stocker)), 2);


        public PrognosisDay PrognosisDay { get; set; }
        // list of employees
        public List<Employee> AvailableEmployees { get; set; }


        public List<UnavailableMoment> UnavailableMomentsOnDay { get; set; }


        public List<Employee> AssignedEmployees { get; set; }

     



        // constructor 
        public RosterDay(PrognosisDay prognosisDay)
        {
            PrognosisDay = prognosisDay;
            Date = prognosisDay.Date;
            AvailableEmployees = new List<Employee>();
            AssignedEmployees = new List<Employee>();
        }
        public RosterDay()
        {
            PrognosisDay = new PrognosisDay();
            AvailableEmployees = new List<Employee>();
            AssignedEmployees = new List<Employee>();
            
        }


        public int GetWeekNumber(DateTime date)
        {
            return System.Globalization.CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        
        public bool IsPlanned(Employee employee, int hour)
        {
            if(PrognosisDay.PlannedShiftsOnDay == null)
            {
                return false;
            }
            List<PlannedShift> shifts = PrognosisDay.PlannedShiftsOnDay.Where(p => p.Employee.Id == employee.Id && p.StartTime.Hour <= hour && p.EndTime.Hour > hour).ToList();
            if (shifts.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsUnavailable(Employee employee, int hour)
        {

            List<UnavailableMoment> unavailable = UnavailableMomentsOnDay.Where(u => u.EmployeeId == employee.Id && u.StartTime.Hour <= hour && u.EndTime.Hour > hour).ToList();
            if (unavailable.Count > 0)
            {
                return true;
            }
            return false;
        }

        public DepartmentEnum GetEmployeeDepartmentShift(Employee employee, int hour)
        {
            if (PrognosisDay.PlannedShiftsOnDay == null)
            {
                return DepartmentEnum.None;
            }
            List<PlannedShift> shifts = PrognosisDay.PlannedShiftsOnDay.Where(p => p.Employee.Id == employee.Id && p.StartTime.Hour <= hour && p.EndTime.Hour > hour).ToList();
            if (shifts.Count > 0)
            {
                return shifts.First().Department;
            }
            return DepartmentEnum.None;
        }

        public double UpdatePrognosisWithoutPlannedHours(DepartmentEnum department)
        {
            double totalHours = 0;
            if (PrognosisDay.PlannedShiftsOnDay == null)
            {
                return 0;
            }
            foreach (var planned in PrognosisDay.PlannedShiftsOnDay)
            {
                if (planned.Department == department)
                {
                    TimeSpan timespan= planned.EndTime - planned.StartTime;
                    totalHours = totalHours + timespan.TotalHours;
                }
            }
            return totalHours;
        }

    }
        

    
}


    
