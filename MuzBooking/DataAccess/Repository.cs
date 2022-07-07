using Infrastructure.CRUDInterfaces;
using Microsoft.EntityFrameworkCore;
using MuzBooking.Entities;

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
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public abstract Task<T> GetByGuidAsync(Guid id);

        public abstract Task<IReadOnlyList<T>> GetListByIdAsync(Guid id);

        public virtual void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
