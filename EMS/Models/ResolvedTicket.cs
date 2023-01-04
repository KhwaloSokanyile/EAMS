using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class ResolvedTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResolveTickectID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public int EmployeeCode { get; set; }

        public DateTime Date { get; set; }

        public string Resolved { get; set; } = string.Empty;

        [ForeignKey("adminId")]
        [Column(Order = 1)]
        public Admin? Admin { get; set; }
        public int adminId { get; set; }

        [ForeignKey("ticketId")]
        [Column(Order = 2)]
        public Ticket? Ticket { get; set; }
        public int ticketId { get; set; }
    }
}
