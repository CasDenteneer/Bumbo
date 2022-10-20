using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumboPOC.Models.DomainModels
{
    public class WorkedShift
    {
        [Key]
        public int WorkedShiftId { get; set; }
        
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsApproved { get; set; }
        public DepartmentEnum Department { get; set; }
        

        public WorkedShift()
        {
            Employee = new Employee();
        }
        
    }
}
