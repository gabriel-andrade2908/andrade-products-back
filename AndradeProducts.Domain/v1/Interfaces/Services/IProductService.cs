﻿using AndradeProducts.Domain.DTOs.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndradeProducts.Domain.v1.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductResponse> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductsResponse>> GetProductsAsync();
        Task<string> InsertProductAsync(ProductRequest productRequest);
        Task<string> DeleteProductAsync(int id);
        Task<string> UpdateProductAsync(ProductRequest productRequest, int id);
    }
}
