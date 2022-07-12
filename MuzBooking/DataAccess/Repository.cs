using Infrastructure.CRUDInterfaces;
using Microsoft.EntityFrameworkCore;
using MuzBooking.Entities;
using System.Linq;
using System.Collections.Generic;

namespace MuzBooking.DataAccess
{
    public abstract class Repository<T> : ICanAddEntity<T>, ICanGetEntity<T>, ICanUpdateEntity<T> where T : AuditableEntity
    {
        private readonly AppDbContext _dbContext;

        protected readonly DbSet<T> dbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }
        public virtual void Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual T GetByGuid(Guid id)
        {
            return dbSet.First(x => x.EquipmentGuid == id);
        }

        public virtual IReadOnlyList<T> GetOrdersById(Guid id)
        {
            return (from e in dbSet where e.EquipmentGuid == id select e).ToList();
        }
        public virtual int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
    }
}
