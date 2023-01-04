using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class SignUp
    {
        [Key]
        [Required(ErrorMessage = "Please enter a email address")]
        [EmailAddress(ErrorMessage ="Please provide a valide email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your Surname")] 
        public string Surname { get; set; } = string.Empty;  

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password, ErrorMessage ="Password does not match")]
        [Compare("ConfirmPassword")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
