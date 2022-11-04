using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BumboPOCData.Enums;

namespace BumboPOCData.DomainModels
{
    public class WorkedShift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkedShiftId { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        [Required]
        public bool IsApproved { get; set; }
        [Required]
        public DepartmentEnum Department { get; set; }


        public WorkedShift()
        {
            Employee = new Employee();
        }

    }
}
