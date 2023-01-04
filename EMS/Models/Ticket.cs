using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TickectID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int EmployeeCode { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; } = string.Empty; 

        [ForeignKey("adminId")]
        [Column(Order = 1)]
        public Admin? Admin { get; set; }
        public int adminId { get; set; }

        [ForeignKey("employeeId")]
        [Column(Order = 2)]
        public Employee? Employee { get; set; }
        public int employeeId { get; set; }
    }
}
