using MuzBooking.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CRUDInterfaces
{
    public interface ICanUpdateEntity<TEntity> where TEntity : AuditableEntity
    {
        void Update(TEntity entity);
    }
}
