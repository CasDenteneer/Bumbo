using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumboPOC.Models
{
    public class Departments
    {
        
        public int EmployeeId { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public DepartmentEnum Department { get; set; }

        // constructor
        public Departments(int employeeId, DepartmentEnum department)
        {
            EmployeeId = employeeId;
            Department = department;
            Employees = new HashSet<Employee>();
        }

        public Departments()
        {
            
           Employees = new HashSet<Employee>();
            
        }


    }
}
