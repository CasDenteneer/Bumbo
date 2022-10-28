
using System.ComponentModel;
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

        [DisplayName("Start tijd")]
        public DateTime StartTime { get; set; }
        [DisplayName("Eind tijd")]
        public DateTime EndTime { get; set; }
        [DisplayName("Telt als werklast zoals school")]
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
