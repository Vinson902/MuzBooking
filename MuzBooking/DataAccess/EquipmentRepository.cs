using MuzBooking.Entities;

namespace MuzBooking.DataAccess
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(AppDbContext dbContext) : base(dbContext) { }

        public Guid CreateEquipment(string name, int amount)
        {
            var guid = Guid.NewGuid();

            Add(new Equipment
            {
                Amount = amount,
                Name = name,
                EquipmentGuid = guid,

            });
            SaveChanges();
            var serviceObject = dbSet.FirstOrDefault(t => t.EquipmentGuid == guid);
            return serviceObject.EquipmentGuid;
        }


        public Guid UpdateEquipment(Guid id, string? name = null, int? amount = null)
        {
            var equimpent = dbSet.FirstOrDefault(e => e.EquipmentGuid == id);
            if (!(amount is null))
                equimpent.Amount = amount.Value;
            if (!(name is null))
                equimpent.Name = name;
            Update(equimpent);
            return equimpent.EquipmentGuid;
        }
       
    }
}
