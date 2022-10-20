using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumboPOC.Models.DatabaseModels
{
    public class Departments
    {
        //[Key]
        //public int DepartmentsId { get; set; }

        [Key]
        public int EmployeeId { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        [EnumDataType(typeof(DepartmentEnum))]
        public DepartmentEnum Department { get; set; }

        // constructor
        public Departments(int employeeId, DepartmentEnum department)
        {
            EmployeeId = employeeId;
            Department = department;

        }

        public Departments()
        {

            Employees = new HashSet<Employee>();

        }


    }
}
