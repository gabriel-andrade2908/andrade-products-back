using System;

namespace AndradeProducts.Domain.v1.Interfaces.Entities
{
    public interface IBaseEntity
    {
        int Id { get; }
        bool IsActive { get; }
        DateTime CreationDate { get; }
        void SetAsActive();
        void SetAsInactive();
    }
}
