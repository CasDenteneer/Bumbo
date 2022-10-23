using BumboPOC.Models.DomainModels;

namespace BumboPOC.Models.ViewModels
{
    public class EmployeeShiftsViewModel
    {
        public Employee Employee { get; set; }
        public List<PlannedShift> PlannedShifts { get; set; }
        
    }
}
