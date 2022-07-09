using MuzBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CRUDInterfaces
{
    public interface ICanGetEntity<TEntity> where TEntity : AuditableEntity
    {
        public TEntity GetByGuid(Guid id);
        public IEnumerable<TEntity> GetAll();

    }
}
