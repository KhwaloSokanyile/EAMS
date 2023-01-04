using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class SignIn
    {
        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }    
    }
}
