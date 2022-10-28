using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumboPOC.Models.DomainModels
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Voornaam")]
        public string FirstName { get; set; }
        [StringLength(25)]
        [DisplayName("Tussennaam")]
        public string? MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Achternaam")]
        public string LastName { get; set; }
     

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Geboortedatum")]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Active werknemer, (Kan ingepland worden)")]
        public bool Active { get; set; }
        [Required]
        [StringLength(45)]
        [RegularExpression(@"^[0-9]{2}-[0-9]{4}-[0-9]{2}$", ErrorMessage = "Bank number must be in the format 00-0000-00")]
        [Display(Name = "Bank nummer")]
        public string BankNumber { get; set; }


        // Employee can have multiple departments, up to 3. 
        public virtual ICollection<Departments> Departments { get; set; }
        
        public virtual ICollection<PlannedShift> PlannedShifts { get; set; }
        public virtual ICollection<WorkedShift> WorkedShifts { get; set; }
        public virtual ICollection<UnavailableMoment> UnavailableMoments { get; set; }





        #region bools for departments and temporary for viewmodel
        [NotMapped]
        [Display(Name = "Vers afdeling")]
        public bool FreshDepartmentEnum { get; set; }
        [NotMapped]
        [Display(Name = "Kassa afdeling")]
        public bool CassiereDepartmentEnum { get; set; }
        [NotMapped]
        [Display(Name = "Vakkenvullers afdeling")]
        public bool StockersDepartment { get; set; }
       

        [NotMapped]
        public string FullName
        {
            get
            {
                { return FirstName + " " + MiddleName + " " + LastName; }
            }
        }
        #endregion
        // constructor without id
        public Employee(string firstName, string middleName, string lastName, DateTime birthDate, string email, bool active, string bankNumber)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Departments = new HashSet<Departments>();
            PlannedShifts = new HashSet<PlannedShift>();
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
            PlannedShifts = new HashSet<PlannedShift>();
            WorkedShifts = new HashSet<WorkedShift>();
            UnavailableMoments = new HashSet<UnavailableMoment>();
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
            PlannedShifts = new HashSet<PlannedShift>();
            WorkedShifts = new HashSet<WorkedShift>();
            UnavailableMoments = new HashSet<UnavailableMoment>();
            BirthDate = birthDate;
            Email = email;
            Active = active;
            BankNumber = bankNumber;
        }

        public Employee()
        {
            Departments = new HashSet<Departments>();
            PlannedShifts = new HashSet<PlannedShift>();
            WorkedShifts = new HashSet<WorkedShift>();
            UnavailableMoments = new HashSet<UnavailableMoment>();
        }
        
  

        


    }
}
