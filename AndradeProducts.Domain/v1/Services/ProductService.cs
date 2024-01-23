using AndradeProducts.Domain.Adapters;
using AndradeProducts.Domain.DTOs.Product;
using AndradeProducts.Domain.Entities;
using AndradeProducts.Domain.Settings.ErrorHandler.ErrorStatusCodes;
using AndradeProducts.Domain.v1.Interfaces.Repositories;
using AndradeProducts.Domain.v1.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException("Product not found");

            ProductResponse productResponse = product.GetProductResponse();

            return productResponse;
        }
        public async Task<IEnumerable<ProductsResponse>> GetProductsAsync()
        {
            IEnumerable<Product> products = await _productRepository.GetManyAsync();

            IEnumerable<ProductsResponse> productResponse = products.GetProductsResponse();

            return productResponse;
        }
        public async Task<string> InsertProductAsync(ProductRequest productRequest)
        {
            Product product = productRequest.GetProductByProductRequest();

            await _productRepository.AddNewAsync(product);
            return "Product added successfully";
        }

        public async Task<string> UpdateProductAsync(ProductRequest productRequest, int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException("Product not found");

            product.UpdateFormData(productRequest.Name, productRequest.Value, productRequest.IsActive);

            await _productRepository.UpdateAsync(product);
            return "Product updated successfully";
        }

        public async Task<string> DeleteProductAsync(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException("Product not found");

            await _productRepository.DeleteAsync(product);
            return "Product deleted successfully";
        }
    }
}
