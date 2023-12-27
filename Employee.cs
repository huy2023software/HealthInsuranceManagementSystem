using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace HealthInsuranceManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }

        [Required(ErrorMessage = "Designation can't be blank")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "JoinDate can't be blank")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        [NotInFuture]
        public System.DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "Salary can't be blank")]
        [DisplayFormat(DataFormatString = "{0: c}")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "First name can't be blank")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name can't be blank")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username can't be blank")]
        [MinLength(8, ErrorMessage = "Username can't less than 8 character")]
        [MaxLength(16, ErrorMessage = "Username can't exceeds than 16 character")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        [MinLength(8, ErrorMessage = "Password can't less than 8 character")]
        [MaxLength(16, ErrorMessage = "Password can't exceeds than 16 character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address can't be blank")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact No can't be blank")]
        [RegularExpression(@"^(\+|0)[0-9]+$", ErrorMessage = "Invalid phone number")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "State can't be blank")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country can't be blank")]
        public string Country { get; set; }

        [Required(ErrorMessage = "City can't be blank")]
        public string City { get; set; }

        [Required(ErrorMessage = "Policy Id can't be blank")]
        public int PolicyId { get; set; }

        [Required(ErrorMessage = "Policy Status can't be blank")]
        public string PolicyStatus { get; set; }

        public virtual Policy Policy { get; set; }
    }
}