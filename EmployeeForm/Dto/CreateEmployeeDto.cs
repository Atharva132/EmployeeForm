using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Dto
{
    public class CreateEmployeeDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
    }
}
