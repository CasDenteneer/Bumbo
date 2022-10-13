using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace BumboPOC.Models
{
    [Index(nameof(PrognosisDay.Date), IsUnique = true)]
    public class PrognosisDay
    {
        //  id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        //  amount of collies and customers, given by the prognosis_input
        [Required]
        [Range(0, 50000)]
        [ModelBinder]
        public int AmountOfCollies { get; set; }
        [Range(0, 50000)]
        [Required]
        [ModelBinder]
        public int AmountOfCustomers { get; set; }
        // date is unique in database, since you only have one prognosis per day.
        [DataType(DataType.Date)]
        [ModelBinder]
        public DateTime Date { get; set; }

        [DisplayName("Kassa Afdeling")]
        public double? CassiereDepartment { get; set; }
        [DisplayName("Vers Afdeling")]
        public double? FreshDepartment { get; set; }
        [DisplayName("VakkenVullers Afdeling")]
        public double? StockersDepartment { get; set; }

        public void updatePrognosis()
        {
            // convert to hours
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


        public PrognosisDay()
        {
            this.updatePrognosis();
        }

       

    }
    
    
}
