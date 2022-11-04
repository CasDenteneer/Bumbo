using BumboData.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumboData
{
    public interface IBumboEmployee
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void SetEmployedStatus(int id, bool status);
        void GetFirstName(int id);
        void GetLastName(int id);
        void GetMiddleName(int id);
        void GetFunction(int id);
        void GetRegion(int id);
    }
}
