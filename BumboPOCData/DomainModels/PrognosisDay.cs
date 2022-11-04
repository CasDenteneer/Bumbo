using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BumboData.DomainModels
{
    public class PrognosisDay
    {
        //  id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<PlannedShift>? PlannedShiftsOnDay { get; set; }


        //  amount of collies and customers, given by the prognosis_input
        [Required]
        public int AmountOfCollies { get; set; }
        [Required]
        public int AmountOfCustomers { get; set; }
        // date is unique in database, since you only have one prognosis per day.
        [Required]
        public DateTime Date { get; set; }

        // this is the prognosis calculated using the norm for each department.

        public double CassiereDepartment { get; set; }
        public double FreshDepartment { get; set; }
        public double StockersDepartment { get; set; }

        public void updatePrognosis()
        {
            // convert to hours
            CassiereDepartment = Norm.CalculateCassieDep(AmountOfCustomers);
            FreshDepartment = Norm.CalculateFreshDep(AmountOfCustomers);
            StockersDepartment = Norm.CalculateStockersDep(AmountOfCollies, AmountOfCustomers);

        }

        // constructor without id
        public PrognosisDay(int amountOfCollies, int amountOfCustomers, DateTime date)
        {
            AmountOfCollies = amountOfCollies;
            AmountOfCustomers = amountOfCustomers;
            Date = date;
            PlannedShiftsOnDay = new HashSet<PlannedShift>();
            updatePrognosis();
        }


        public double MinutsTohHours(double Minutes)
        {
            // converts from minutes to hours, rounding the minutes
            double Temp = 0;
            Temp = (double)(Minutes % 60) / 100;
            var n = (double)Minutes / 60;
            return Math.Floor((double)Minutes / 60) + Temp;
        }


        public PrognosisDay()
        {
            updatePrognosis();
        }


    }
}
