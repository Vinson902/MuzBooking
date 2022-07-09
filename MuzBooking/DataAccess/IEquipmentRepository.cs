using Infrastructure.CRUDInterfaces;
using MuzBooking.Entities;

namespace MuzBooking.DataAccess
{
    public interface IEquipmentRepository : ICanGetEntity<Equipment>, ICanAddEntity<Equipment> 
    {
        public Guid CreateEquipment(string name, int amount);
        public Guid UpdateEquipment(Guid guid, string? name = null, int? amount = null);
    }
}
