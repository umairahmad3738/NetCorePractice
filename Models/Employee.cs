using System.ComponentModel.DataAnnotations;

namespace kudvenkitPractice.Models
{
    public class Employee
    {
        public int Id { get; set; }
        //[Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }
        //[Required]
        public GenderEnums? Gender { get; set; }
        //[Required]
        public DepartmentEnums? Department { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-]+)(\.[a-zA-Z]{2,5}){1,2}$", ErrorMessage = "Invalid Email")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
    }


}
