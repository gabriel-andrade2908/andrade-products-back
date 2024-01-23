using AndradeProducts.Domain.v1.Interfaces.Entities;
using System;

namespace AndradeProducts.Domain.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        protected BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
            SetAsActive();
        }

        public int Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsActive { get; protected set; }

        public void SetAsInactive()
        {
            IsActive = false;
        }

        public void SetAsActive()
        {
            IsActive = true;
        }
    }
}
