using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumboPOC.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                { return FirstName + " " + MiddleName +  " " + LastName; }
            }
        }
        
        [Required]
        public string Department { get; set; }


        // constructor without id
        public Employee(string firstName, string middleName, string lastName, string department)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Department = department;
        }

    }
}
