

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumboPOC.Models.DomainModels
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
        [DisplayName("Startijd")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Required]
        [DisplayName("EindTijd")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        [Required]
        [DisplayName("Afdeling")]
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
            Employee = new Employee();
            PrognosisDay = new PrognosisDay();
        }
    }
}
