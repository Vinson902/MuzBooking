
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuzBooking.Entities
{
    public class ServiceObject : AuditableEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        [ForeignKey("Equipment")]
        public Guid EquipmentId { get; set; }
        public int AvailableAmount { get; set; }
        public string? Error { get; set; }


    }
}
