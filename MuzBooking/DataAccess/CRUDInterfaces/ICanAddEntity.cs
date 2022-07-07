using System;
using System.Collections.Generic;
using System.Text;
using MuzBooking.Entities;

namespace Infrastructure.CRUDInterfaces
{
    public interface ICanAddEntity<TEntity> where TEntity : AuditableEntity
    {
        void Add(TEntity entity);
    }
}
