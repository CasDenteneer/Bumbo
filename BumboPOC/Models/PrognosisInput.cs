namespace BumboPOC.Models
{
    public class PrognosisInput
    {
        //  id
        public int Id { get; set; }
        //  amount of collies and customers, given by the prognosis_input
        public int AmountOfCollies { get; set; }

        public int AmountOfCustomers { get; set; }

        public DateTime Date { get; set; }

        public Prognosis CassiereDepartment { get; set; }
        public Prognosis FreshDepartment { get; set; }
        public Prognosis StockersDepartment { get; set; }

        public void updatePrognosis()
        {
            CassiereDepartment.MinutesToBeScheduled = Norm.CassiereTimePerCustomerMinutes * AmountOfCustomers;
            FreshDepartment.MinutesToBeScheduled = Norm.FreshDepartmentTimePerCustomerMinutes * AmountOfCustomers;
            StockersDepartment.MinutesToBeScheduled = (Norm.StockingTimePerCollieMinutes * AmountOfCollies) +
                (Norm.CollieUnloadTimePerCollieMinutes * AmountOfCollies);
        }
        
        // constructor without id
        
        
        
    }
}
