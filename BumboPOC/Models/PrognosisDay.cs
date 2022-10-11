namespace BumboPOC.Models
{
    public class PrognosisDay
    {
        //  id
        public int Id { get; set; }
        //  amount of collies and customers, given by the prognosis_input
        public int AmountOfCollies { get; set; }

        public int AmountOfCustomers { get; set; }

        public DateTime Date { get; set; }

        public PrognosisDepartment CassiereDepartment { get; set; }
        public PrognosisDepartment FreshDepartment { get; set; }
        public PrognosisDepartment StockersDepartment { get; set; }

        public void updatePrognosis()
        {
            CassiereDepartment.MinutesToBeScheduled = Norm.CassiereTimePerCustomerMinutes * AmountOfCustomers;
            FreshDepartment.MinutesToBeScheduled = Norm.FreshDepartmentTimePerCustomerMinutes * AmountOfCustomers;
            StockersDepartment.MinutesToBeScheduled = (Norm.StockingTimePerCollieMinutes * AmountOfCollies) +
                (Norm.CollieUnloadTimePerCollieMinutes * AmountOfCollies);
        }

        // constructor without id
        public PrognosisDay(int amountOfCollies, int amountOfCustomers, DateTime date)
        {
            AmountOfCollies = amountOfCollies;
            AmountOfCustomers = amountOfCustomers;
            Date = date;
            CassiereDepartment = new PrognosisDepartment(Department.Cassiere, 0);
            FreshDepartment = new PrognosisDepartment(Department.Fresh, 0);
            StockersDepartment = new PrognosisDepartment(Department.Stocker, 0);
            updatePrognosis();
        }


    
        
        



    }
}
