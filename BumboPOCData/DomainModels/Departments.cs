using BumboPOCData.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumboPOCData.DomainModels
{
    public class Departments
    {
        [Key]
        public int EmployeeId { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        [EnumDataType(typeof(DepartmentEnum))]
        public DepartmentEnum Department { get; set; }

        public Departments()
        {

        }

    }
}
