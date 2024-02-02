using AndradeProducts.Domain.DTOs.Product;
using AndradeProducts.Domain.Entities;
using AndradeProducts.Domain.Settings.ErrorHandler.ErrorStatusCodes;
using AndradeProducts.Domain.v1.Interfaces.Repositories;
using AndradeProducts.Domain.v1.Interfaces.Services;
using Logistics.Domain.Services;
using Moq;
using Xunit;

namespace AndradeProducts.Tests.Services
{
    public class ProductServiceTests
    {

        private readonly IProductService _productService;
        private readonly Mock<IProductRepository> _productRepository;
        const int productId = 1;

        public ProductServiceTests()
        {
            _productRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepository.Object);
        }

        [Fact]
        public async Task GetProductByIdAsync_IdFound_ReturnProduct()
        {
            var product = new Product("Shirt", 50);

            _productRepository.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(product);

            ProductResponse result = await _productService.GetProductByIdAsync(productId);

            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Value, result.Value);
            Assert.Equal(product.IsActive, result.IsActive);
        }

        [Fact]
        public async Task GetProductByIdAsync_IdNotFound_ReturnNotFoundException()
        {
            NotFoundException exception = await Assert.ThrowsAsync<NotFoundException>(() =>  _productService
            .GetProductByIdAsync(productId));

            Assert.Equal("Product not found", exception.Errors[0]);
        }

        [Fact]
        public async Task InsertNewProductAsync_AddProductInDatabase()
        {
            var productRequest = new NewProductRequest { Name = "Shirt", Value = 80};

            string result = await _productService.InsertProductAsync(productRequest);

            _productRepository.Verify(repository => repository.AddNewAsync(It.IsAny<Product>()), Times.Once);

            Assert.Equal("Product added successfully", result);
        }

        [Fact]
        public async Task UpdateProductAsync_IdFound_UpdateProductInDatabase()
        {
            var productRequest = new ProductUpdateRequest { IsActive = false, Name = "T-Shirt", Value = 100 };

            var product = new Product("Shirt", 80);

            _productRepository.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(product);

            string result = await _productService.UpdateProductAsync(productRequest, productId);

            _productRepository.Verify(repository => repository.UpdateAsync(product), Times.Once);

            Assert.Equal(productRequest.IsActive, product.IsActive);
            Assert.Equal(productRequest.Name, product.Name);
            Assert.Equal(productRequest.Value, product.Value);
            Assert.Equal("Product updated successfully", result);
        }

        [Fact]
        public async Task UpdateProductAsync_IdNotFound_ReturnNotFoundException()
        {
            var productRequest = new ProductUpdateRequest { IsActive = false, Name = "T-Shirt", Value = 100 };

            NotFoundException exception = await Assert.ThrowsAsync<NotFoundException>(() => _productService
            .UpdateProductAsync(productRequest, 1));

            Assert.Equal("Product not found", exception.Errors[0]);
        }

        [Fact]
        public async Task DeleteProductAsync_IdFound_DeleteProductInDatabase()
        {
            var product = new Product("Shirt", 80);

            _productRepository.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(product);

            string result = await _productService.DeleteProductAsync(productId);

            _productRepository.Verify(repository => repository.DeleteAsync(product), Times.Once);

            Assert.Equal("Product deleted successfully", result);
        }

        [Fact]
        public async Task DeleteProductAsync_IdNotFound_ReturnNotFoundException()
        {
            NotFoundException exception = await Assert.ThrowsAsync<NotFoundException>(() => _productService
            .DeleteProductAsync(1));

            Assert.Equal("Product not found", exception.Errors[0]);
        }
    }
}
