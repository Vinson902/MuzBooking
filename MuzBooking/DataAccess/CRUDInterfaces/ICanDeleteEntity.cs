using MuzBooking.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CRUDInterfaces
{
    public interface ICanDeleteEntity<TEntity> where TEntity : AuditableEntity
    {
        void Remove(TEntity entity);
    }
}
