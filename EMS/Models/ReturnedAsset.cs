using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class ReturnedAsset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReturnID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public int EmployeeCode { get; set; }

        public DateTime Date { get; set; }

        public string AssetType { get; set; } = string.Empty;

        public string Comments { get; set; } = string.Empty;

        [ForeignKey("adminId")]
        [Column(Order = 1)]
        public Admin? Admin { get; set; }
        public int adminId { get; set; }

        [ForeignKey("employeeId")]
        [Column(Order = 2)]
        public Employee? Employee { get; set; }
        public int employeeId { get; set; }

        [ForeignKey("assetId")]
        [Column(Order = 3)]
        public Asset? Asset { get; set; }
        public int assetId { get; set; }
    }
}
