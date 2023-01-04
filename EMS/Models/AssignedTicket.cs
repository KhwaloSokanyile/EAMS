using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class AssignedTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AssignedTicketsId { get; set; }

        public DateTime Date { get;set; }

        public string Name { get; set; } = string.Empty;

        public int EmployeeCode { get;set; }

        public string Priority { get; set; } = string.Empty;

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
