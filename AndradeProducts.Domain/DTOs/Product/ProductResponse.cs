using System;

namespace AndradeProducts.Domain.DTOs.Product
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
