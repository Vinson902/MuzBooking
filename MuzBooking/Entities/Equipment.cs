using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MuzBooking.Entities
{
    public class Equipment : AuditableEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int Amount { get; set; }

        [JsonIgnore]
        public ICollection<ServiceObject> serviceObjects { get; set; }
    }
}
