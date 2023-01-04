using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;
    }
}
