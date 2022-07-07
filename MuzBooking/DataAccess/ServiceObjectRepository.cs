using MuzBooking.Entities;

namespace MuzBooking.DataAccess
{
    public class ServiceObjectRepository : Repository<ServiceObject>
    {
        public ServiceObjectRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void Add(ServiceObject entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ServiceObject>> CreateBooking(string name, int amount)
        {

           dbSet.Add(new ServiceObject
            {
               Amount = amount,
                Name = name,

            });
        }

        public Task<IReadOnlyList<ServiceObject>> CreateEquipment()
        {
            throw new NotImplementedException();
        }

        public async override Task<ServiceObject> GetByGuidAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async override Task<IReadOnlyList<ServiceObject>> GetListByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Update(ServiceObject entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ServiceObject>> UpdateEquipment()
        {
            throw new NotImplementedException();
        }
    }
}
