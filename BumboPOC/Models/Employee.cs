namespace BumboPOC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }


        // constructor without id
        public Employee(string name, string department)
        {
            Name = name;
            Department = department;
        }

    }
}
