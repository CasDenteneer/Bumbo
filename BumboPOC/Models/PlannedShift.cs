

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumboPOC.Models
{
    public class PlannedShift
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }
        [Required]
        public DepartmentEnum Department { get; set; }

    }
}
