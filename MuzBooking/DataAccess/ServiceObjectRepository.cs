using MuzBooking.Entities;

namespace MuzBooking.DataAccess
{
    public class ServiceObjectRepository : Repository<ServiceObject>, IServiceObjectRepository
    {
        public ServiceObjectRepository(AppDbContext dbContext) : base(dbContext) { }

        public void CreateBooking(Guid id, string name, int amount, int equipmentId)
        {
            Add(new ServiceObject
            {
                Name = name,
                Amount = amount,
                EquipmentId = equipmentId,
                EquipmentGuid = id
            });
        }


    }
}
