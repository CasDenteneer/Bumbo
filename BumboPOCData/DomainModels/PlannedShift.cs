using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BumboData.Enums;

namespace BumboData.DomainModels
{
    public class PlannedShift
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ShiftId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int PrognosisId { get; set; }
        public virtual PrognosisDay PrognosisDay { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public DepartmentEnum Department { get; set; }


        public PlannedShift(int employeeId, DateTime startTime, DateTime endTime, DepartmentEnum department)
        {
            EmployeeId = employeeId;
            Employee = new Employee();
            PrognosisDay = new PrognosisDay();
            StartTime = startTime;
            EndTime = endTime;
            Department = department;
        }
        public PlannedShift()
        {
        }
    }
}
