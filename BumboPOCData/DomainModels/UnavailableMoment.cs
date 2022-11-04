using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumboPOCData.DomainModels
{
    public class UnavailableMoment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnavailableMomentId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
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
