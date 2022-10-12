namespace BumboPOC.Models
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
        
      
        
        

    }
}
