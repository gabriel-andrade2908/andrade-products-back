﻿namespace AndradeProducts.Domain.DTOs.Product
{
    public class ProductUpdateRequest
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
    }
}
