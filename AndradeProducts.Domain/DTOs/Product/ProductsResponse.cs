using System;

namespace AndradeProducts.Domain.DTOs.Product
{
    public class ProductsResponse
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public decimal Value { get; set; } 
        public bool IsActive { get; set; }
        public string CreationDate { get; set; }
    }
}
