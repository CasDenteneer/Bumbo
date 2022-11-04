
using BumboPOCData;
using BumboPOCData.DomainModels;

namespace BumboServices
{
    public class BumboEmployeeService : IBumboEmployee
    {
        private MyContext _context;
        public BumboEmployeeService(MyContext _myContext)
        {
            _context = _myContext;
        }


        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public void GetFirstName(int id)
        {
            throw new NotImplementedException();
        }

        public void GetFunction(int id)
        {
            throw new NotImplementedException();
        }

        public void GetLastName(int id)
        {
            throw new NotImplementedException();
        }

        public void GetMiddleName(int id)
        {
            throw new NotImplementedException();
        }

        public void GetRegion(int id)
        {
            throw new NotImplementedException();
        }

        public void SetEmployedStatus(int id, bool status)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}