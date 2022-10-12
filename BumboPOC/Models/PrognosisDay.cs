using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumboPOC.Models
{
    public class PrognosisDay
    {
        //  id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        //  amount of collies and customers, given by the prognosis_input
        [Required]
        [Range(0, 50000)]
        public int AmountOfCollies { get; set; }
        [Range(0, 50000)]
        [Required]
        public int AmountOfCustomers { get; set; }

        public DateTime Date { get; set; }

        public double CassiereDepartment { get; set; }
        public double FreshDepartment { get; set; }
        public double StockersDepartment { get; set; }

        public void updatePrognosis()
        {
            // convert to hours
            TimeSpan TotalTimeCassierre = TimeSpan.FromMinutes(Norm.CassiereTimePerCustomerMinutes * AmountOfCustomers);
            TimeSpan TotalTimeFresh = TimeSpan.FromMinutes(Norm.FreshDepartmentTimePerCustomerMinutes * AmountOfCustomers);
            TimeSpan TotalTimeStockers = TimeSpan.FromMinutes((Norm.StockingTimePerCollieMinutes * AmountOfCollies) +
                (Norm.CollieUnloadTimePerCollieMinutes * AmountOfCollies));

            CassiereDepartment = TotalTimeCassierre.TotalHours;
            FreshDepartment = TotalTimeStockers.TotalHours;
            StockersDepartment = TotalTimeStockers.TotalHours;


            CassiereDepartment = MinutsTohHours(Norm.CassiereTimePerCustomerMinutes * AmountOfCustomers);
            FreshDepartment = MinutsTohHours(Norm.FreshDepartmentTimePerCustomerMinutes * AmountOfCustomers);
            StockersDepartment = MinutsTohHours((Norm.StockingTimePerCollieMinutes * AmountOfCollies) +
                (Norm.CollieUnloadTimePerCollieMinutes * AmountOfCollies));
            
        }

        // constructor without id
        public PrognosisDay(int amountOfCollies, int amountOfCustomers, DateTime date)
        {
            AmountOfCollies = amountOfCollies;
            AmountOfCustomers = amountOfCustomers;
            Date = date;
            updatePrognosis();
        }


        public double MinutsTohHours(double Minutes)
        {
            // converts from minutes to hours, rounding the minutes
            double Temp = 0;
            Temp = ((double)(Minutes % 60) / 100);
            var n = (double)Minutes / 60;
            return Math.Floor((double)Minutes / 60) + Temp;
        }

    }
    
    
}
