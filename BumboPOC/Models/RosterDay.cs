using Microsoft.CodeAnalysis.CSharp.Syntax;

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


        public PrognosisDay PrognosisDay { get; set; }
        // list of employees
        public List<Employee> AvailableEmployees { get; set; }


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
            if (AssignedEmployees.Contains(employee) != true)
            {
                return false;
            }
            if (employee.PlannedShifts == null)
            {
                return false;
            }

            foreach (PlannedShift plannedShift in employee.PlannedShifts)
            {
                if (plannedShift.PrognosisDay.Date == Date)
                {
                    // if the employee is scheduled on the day and the hour is between the start and end time of the shift return true
                    if (plannedShift.StartTime.Hour <= hour && plannedShift.EndTime.Hour > hour)
                    {
                        return true;
                    }
                }
               
            }
            return false;
        }
        

    }
}


    
