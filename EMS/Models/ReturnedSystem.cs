using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class ReturnedSystem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReturnId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the Employee Code")]
        public int EmployeeCode { get; set; }

        [Required(ErrorMessage = "Please enter the Date of return")]
        public DateTime Date { get; set; }

        public string SystemName { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage ="The number of characters must be between 2 - 500")]
        [MinLength(2, ErrorMessage = "The minimun number of characters must be 2")]
        public string Comments { get; set;} = string.Empty;

        [ForeignKey("adminId")]
        [Column(Order = 1)]
        public Admin? Admin { get; set; }
        public int adminId { get; set; }

        [ForeignKey("employeeId")]
        [Column(Order = 2)]
        public Employee? Employee { get; set; }
        public int employeeId { get; set; }

        [ForeignKey("buildsystemId")]
        [Column(Order = 3)]
        public BuildSystem? BuildSystem { get; set; }
        public int buildsystemId { get; set; }
    }
}
