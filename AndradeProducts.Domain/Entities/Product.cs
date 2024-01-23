using AndradeProducts.Domain.Entities.Base;

namespace AndradeProducts.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product(string name, decimal value, bool isActive) 
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public decimal Value { get; private set; }

        public void UpdateFormData(string name, decimal value, bool isActive)
        {
            Name = name;
            Value = value;
            IsActive = isActive;
        }
    }
}
