using Microsoft.AspNetCore.Mvc.Rendering;
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
        [StringLength(25)]
        public string? MiddleName { get; set; }
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

        // birthdate, email, bool active employee, bank number
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [StringLength(45)]
        [RegularExpression(@"^[0-9]{2}-[0-9]{4}-[0-9]{2}$", ErrorMessage = "Bank number must be in the format 00-0000-00")]
        [Display(Name = "Bank number")]
        public string BankNumber { get; set; }

        // Employee can have multiple departments
        public virtual ICollection<Departments> Departments { get; set; }

        [NotMapped]
        [Display(Name = "Vers afdeling")]
        public bool FreshDepartmentEnum { get; set; }
        [NotMapped]
        [Display(Name = "Kassa afdeling")]
        public bool CassiereDepartmentEnum { get; set; }
        [NotMapped]
        [Display(Name = "Vakkenvullers afdeling")]
        public bool StockersDepartment { get; set; }

        // constructor without id
        public Employee(string firstName, string middleName, string lastName, DateTime birthDate, string email, bool active, string bankNumber)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Departments = new HashSet<Departments>();
            BirthDate = birthDate;
            Email = email;
            Active = active;
            BankNumber = bankNumber;
        }
        // constructor without middle name
        public Employee(string firstName, string lastName, DateTime birthDate, string email, bool active, string bankNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Departments = new HashSet<Departments>();
            BirthDate = birthDate;
            Email = email;
            Active = active;
            BankNumber = bankNumber;
        }




        public Employee(string firstName, string lastName, List<DepartmentEnum> departments, DateTime birthDate, string email, bool active, string bankNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Departments = new HashSet<Departments>();
            BirthDate = birthDate;
            Email = email;
            Active = active;
            BankNumber = bankNumber;
        }

        public Employee()
        {
            Departments = new HashSet<Departments>();
        }



    }
}
