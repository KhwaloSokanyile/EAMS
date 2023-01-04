using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Please enter the Name of the employee")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the Surnme of the employee")]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the ID Number of the employee")]
        public int IDNumber { get; set; }

        public string Email { get; set; } = string.Empty;   

        [Required(ErrorMessage = "Please enter the Department of the employee")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the Employee Code")]
        public int EmployeeCode { get; set; }

        [Required(ErrorMessage = "Please enter the Job Description of the employee")]
        public string JobDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the Employee Type")]
        public string EmployeeType { get; set; } = string.Empty;


        [ForeignKey("adminId")]
        public Admin? Admin { get; set; }
        public int adminId { get; set; }

    }
}
