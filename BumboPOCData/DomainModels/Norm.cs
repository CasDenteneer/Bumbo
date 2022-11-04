using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumboData.DomainModels
{
    public static class Norm
    {
        /// <summary>
        /// Coli unloading	5 minutes
        //stocking	30 minutes per coli
        //cassiere	1 Kassière 30 klanten per uur
        //FreshDerpartment  1 employee per 100 customers per hour
        //arranging shelfs	30 seconds per meter

        // these values are the norm used to calculate the
        // final prognosis using the amount of collies and customers
        // activties:
        /// </summary>
        /// 
        // 
        public static int CollieUnloadTimePerCollieMinutes = 5;
        public static int StockingTimePerCollieMinutes = 30;
        public static int CassiereTimePerCustomerMinutes = 2;
        public static double FreshDepartmentTimePerCustomerMinutes = 1.6;
        public static int ArrangingShelfsTimePerMeterMinutes = 30;

        public static double CalculateCassieDep(int amountOfCustomers)
        {
            return MinutsTohHours(CassiereTimePerCustomerMinutes * amountOfCustomers);
        }

        public static double CalculateFreshDep(int amountOfCustomers)
        {
            return MinutsTohHours(FreshDepartmentTimePerCustomerMinutes * amountOfCustomers);
        }

        public static double CalculateStockersDep(int amountOfCollies, int amountOfCustomers)
        {
            return MinutsTohHours(StockingTimePerCollieMinutes * amountOfCollies +
                CollieUnloadTimePerCollieMinutes * amountOfCollies);
        }

        public static double MinutsTohHours(double Minutes)
        {
            // converts from minutes to hours, rounding the minutes
            double Temp = 0;
            Temp = (double)(Minutes % 60) / 100;
            var n = (double)Minutes / 60;
            return Math.Floor((double)Minutes / 60) + Temp;
        }



    }
}
