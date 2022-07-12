
using System.Text.Json.Serialization;

namespace MuzBooking.Entities
{
    public class ServiceObjectDto 
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public int AvailableAmount { get; set; }
        public int Amount { get; set; }
        public Guid EquipmentGuid { get; set; }
    }
}
