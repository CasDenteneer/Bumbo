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
        public List<Employee>? AvailableEmployees { get; set; }


        public List<Employee>? AssignedEmployees { get; set; }

        // constructor 
        public RosterDay(PrognosisDay prognosisDay)
        {
            PrognosisDay = prognosisDay;
            Date = prognosisDay.Date;
            AvailableEmployees = new List<Employee>();
            AssignedEmployees = new List<Employee>();
        }


        public int GetWeekNumber(DateTime date)
        {
            return System.Globalization.CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }


    }
}
