using System.ComponentModel.DataAnnotations;

namespace MuzBooking.Entities
{
    public class Equipment : AuditableEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int Amount { get; set; }
        public Guid Equipmentid { get; set; }
    }
}
