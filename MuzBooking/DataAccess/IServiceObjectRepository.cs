using Infrastructure.CRUDInterfaces;
using MuzBooking.Entities;

namespace MuzBooking.DataAccess
{
    public interface IServiceObjectRepository :
        ICanAddEntity<ServiceObject>,ICanGetEntity<ServiceObject>,ICanUpdateEntity<ServiceObject>
    {
        public Task<IReadOnlyList<ServiceObject>> CreateEquipment();
        public Task<IReadOnlyList<ServiceObject>> UpdateEquipment();
        public Task<IReadOnlyList<ServiceObject>> CreateBooking();
    }
}
