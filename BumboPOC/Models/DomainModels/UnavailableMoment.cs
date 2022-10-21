
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumboPOC.Models.DomainModels
{
    public class UnavailableMoment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnavailableMomentId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        
        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAccountedForInWorkLoad { get; set; }

        public UnavailableMoment(int employeeId, DateTime startTime, DateTime endTime, bool isAccountedForInWorkLoad)
        {
            EmployeeId = employeeId;
            Employee = new Employee();
            StartTime = startTime;
            EndTime = endTime;
            IsAccountedForInWorkLoad = isAccountedForInWorkLoad;
        }

        public UnavailableMoment()
        {
            Employee = new Employee();
        }
    }
}
