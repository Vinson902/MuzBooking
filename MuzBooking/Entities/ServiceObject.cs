
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MuzBooking.Entities
{
    public class ServiceObject : AuditableEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [ForeignKey("Equipment")]
        [JsonIgnore]
        public int EquipmentId { get; set; }
        [JsonIgnore]
        public Equipment Equipment { get; set; }


    }
}
