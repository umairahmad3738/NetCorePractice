using kudvenkitPractice.Models;
using System.ComponentModel.DataAnnotations;

namespace kudvenkitPractice.ViewModels
{
    public class BaseViewModel
    {
        #region Properties

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }
        [Required]
        public GenderEnums? Gender { get; set; }
        [Required]
        public DepartmentEnums? Department { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-]+)(\.[a-zA-Z]{2,5}){1,2}$", ErrorMessage = "Invalid Email")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        public IFormFile Photo { get; set; }

        #endregion


        #region Methods
        public string SetEmployeeImage(string path = "", string gender = "")
        {
            string photoPath = string.Empty;
            if (string.IsNullOrEmpty(path))
            {
                if (gender.ToLower().Equals("male"))
                {
                    photoPath = "~/images/avatarMale.jpg";
                }
                else
                {
                    photoPath = "~/images/avatarFemale.jpg";
                }
            }
            else
            {
                photoPath = "~/images/" + path;
            }

            return photoPath;
        }
        #endregion

    }
}
