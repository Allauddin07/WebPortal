using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebPortal.Models
{
    public class SignIn
    {
        
        [Required(ErrorMessage = "Please enter email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter valid email ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter ConfirmPassword")]
        [DataType(DataType.Password)]
        public string Password { get; set; }        
    }
}
