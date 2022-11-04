
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BumboPOCData.DomainModels
{
    public class Employee
    {

        // These are the values mentioned in the casus:
        // BID	Vn	Tv	An	Geboortedatum	Leeftijd	Postcode	Huisnummer	Telefoon	Email	In dienst sinds 	
        // Functie	Schaal	KAS	VER	VAK	SER


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }


        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool IsEmployed { get; set; }

        // bank number is not used currently in any use cases.
        [Required]
        public string BankNumber { get; set; }


        [Required]
        public string Function { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        [Required]
        public DateTime EmployeeJoinedCompany { get; set; }

        //// Not described in use cases, only once in casus
        //public int Scale { get; set; }

        // the manager of the employee, can be null
        public int? ManagerId { get; set; }
        public virtual Employee? Manager { get; set; }






        // Employee can have multiple departments, up to 3. 
        public virtual ICollection<Departments> Departments { get; set; }

        public virtual ICollection<PlannedShift> PlannedShifts { get; set; }
        public virtual ICollection<WorkedShift> WorkedShifts { get; set; }
        public virtual ICollection<UnavailableMoment> UnavailableMoments { get; set; }

        public int MaxHoursInWeekAllowed
        {
            get { return 40; } // TEMPORARY
            // TODO get from database, base this on contract / CAO rules
        }


        public Employee()
        {
        }





    }
}
