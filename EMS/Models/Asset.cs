
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class Asset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId { get; set; }

        public string AssetType { get; set; } = string.Empty;

        public string Purpose { get; set; } = string.Empty;     

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
