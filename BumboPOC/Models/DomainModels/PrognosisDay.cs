using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace BumboPOC.Models.DomainModels
{
    [Index(nameof(Date), IsUnique = true)]
    public class PrognosisDay
    {
        //  id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<PlannedShift>? PlannedShiftsOnDay { get; set; }


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
            StockersDepartment = MinutsTohHours(Norm.StockingTimePerCollieMinutes * AmountOfCollies +
                Norm.CollieUnloadTimePerCollieMinutes * AmountOfCollies);

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

        public double UpdatePrognosis(List<PlannedShift> PlannedShifts)
        {
            double totalHours = 0;
            foreach (var planned in PlannedShifts)
            {
                if (planned.PrognosisDay.Date == Date)
                {
                    TimeSpan time = planned.EndTime - planned.StartTime;
                    // reduce the value in the department by the time
                    switch (planned.Department)
                    {
                        case DepartmentEnum.Cassiere:
                            CassiereDepartment = Math.Round((double)(CassiereDepartment - time.TotalHours), 2);
                            break;
                        case DepartmentEnum.Fresh:
                            FreshDepartment = Math.Round((double)(FreshDepartment - time.TotalHours), 2);
                            break;
                        case DepartmentEnum.Stocker:
                            StockersDepartment = Math.Round((double)(StockersDepartment - time.TotalHours), 2);
                            break;
                        default:
                            break;
                    }
                }

            }
            return totalHours;
        }




    }


}
