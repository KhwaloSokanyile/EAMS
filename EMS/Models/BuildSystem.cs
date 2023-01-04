using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class BuildSystem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string SystemName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the Employee Code")]
        public int EmployeeCode { get; set; }

        public int MemorySize { get; set; }

        public string Mouse { get; set; } = string.Empty;   

        public string Keyboard { get; set; } = string.Empty;    

        public string Monitor { get; set; } = string.Empty; 

        [ForeignKey("adminId")]
        [Column(Order =1)]
        public Admin? Admin { get; set; }
        public int adminId { get; set; }

        [ForeignKey("employeeId")]
        [Column(Order = 2)]
        public Employee? Employee { get; set; }
        public int employeeId { get; set; }

        

    }
}
