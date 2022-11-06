using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WebPortal.Models
{
    public class SignUp
    {
        
        [Required(ErrorMessage="Please enter name")]
        public string FullName { get; set; }

        [Required(ErrorMessage="Please enter email")]
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage ="Please enter valid email ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter ConfirmPassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }   
        

        
    }
}
