using BumboPOC.Models;
using BumboPOC.Models.DomainModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BumboPOC.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee employee { get; set; }

        
        public string FullName
        {
            get
            {
                { return employee.FirstName + " " + employee.MiddleName + " " + employee.LastName; }
            }
        }


        [Display(Name = "Vers afdeling")]
        public bool FreshDepartmentEnum { get; set; }

        [Display(Name = "Kassa afdeling")]
        public bool CassiereDepartmentEnum { get; set; }

        [Display(Name = "Vakkenvullers afdeling")]
        public bool StockersDepartment { get; set; }


        public EmployeeViewModel()
        {
            employee = new Employee();
        }

    }
}
