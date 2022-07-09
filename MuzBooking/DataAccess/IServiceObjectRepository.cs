using Infrastructure.CRUDInterfaces;
using MuzBooking.Entities;

namespace MuzBooking.DataAccess
{
    public interface IServiceObjectRepository :
        ICanAddEntity<ServiceObject>,ICanGetEntity<ServiceObject>,ICanUpdateEntity<ServiceObject>
    {
        public void CreateBooking(Guid id, string name, int amount, int equipmentId);
    }
}
