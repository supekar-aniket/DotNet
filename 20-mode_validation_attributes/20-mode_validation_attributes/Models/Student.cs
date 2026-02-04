using System.ComponentModel.DataAnnotations;

namespace _20_mode_validation_attributes.Models
{
    public class Student
    {
        [Required (ErrorMessage = "Please Enter Name")]
        [Display(Name="Student Name")]
        //[MaxLength(15)]
        //[MinLength(3)]
        [StringLength(15,MinimumLength = 3,ErrorMessage = "Minimum 3 and Maximum 15 characters")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Please Enter Email")]
        //[EmailAddress]
        //public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [Display(Name = "Student Email")]
        [RegularExpression("^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$",ErrorMessage ="Invaid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Age")]
        [Display(Name = "Student Age")]
        [Range(18,110,ErrorMessage = "Age is between 10 to 110")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name ="Your password")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}