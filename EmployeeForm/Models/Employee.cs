using System.ComponentModel.DataAnnotations﻿;

namespace EmployeeForm.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, ErrorMessage = "First Name cannot be longer than 20 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name must contain only alphabets.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, ErrorMessage = "Last Name cannot be longer than 20 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name must contain only alphabets.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Employee Code is required")]

        public int EmployeeCode { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [Range(1000000000, 9999999999, ErrorMessage = "Contact number must be a 10-digit number.")]
        public string Contact { get; set; } = null!;

        [Required(ErrorMessage = "DoB is required")]
        [DataType(DataType.Date, ErrorMessage = "Date of Birth must be a valid date.")]
        public DateTime DoB { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(10, ErrorMessage = "Address cannot be longer than 10 characters.")]
        public string Address { get; set; } = null!;
    }
}
