using AndradeProducts.Domain.DTOs.Product;
using AndradeProducts.Domain.Entities;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace AndradeProducts.Domain.Adapters
{
    public static class ProductAdapter
    {
        public static ProductResponse GetProductResponse(this Product product)
        {
            return new ProductResponse
            {
                IsActive = product.IsActive,
                Name = product.Name,    
                Value = product.Value,  
                CreationDate = product.CreationDate
            };
        }

        public static IEnumerable<ProductsResponse> GetProductsResponse(this IEnumerable<Product> products)
        {
            return products.Select(product => new ProductsResponse
            {
                IsActive = product.IsActive,
                Name = product.Name,
                Value = product.Value,
                Id = product.Id,
                CreationDate = product.CreationDate.ToString("dd-MM-yyyy")
            }).AsEnumerable();
        }

        public static Product GetProductByProductRequest(this ProductRequest productRequest)
        {
            return new Product(productRequest.Name, productRequest.Value, productRequest.IsActive);
        }
    }
}
