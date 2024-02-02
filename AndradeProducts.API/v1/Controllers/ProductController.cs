using AndradeProducts.API.v1.Controllers.Base;
using AndradeProducts.Domain.DTOs.Product;
using AndradeProducts.Domain.v1.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logistics.Application.v1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/product/")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Returns a product by id")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(ProductResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Product not found", typeof(string))]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productService.GetProductByIdAsync(id));
        }

        [HttpGet]
        [SwaggerOperation("List all products")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(IList<ProductsResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Product not found", typeof(string))]
        public async Task<IActionResult> Getproducts()
        {
            return Ok(await _productService.GetProductsAsync());
        }

        [HttpPost]
        [SwaggerOperation("Insert new product")]
        [SwaggerResponse(StatusCodes.Status200OK, "Product added successfully", typeof(string))]
        public async Task<IActionResult> Insertproduct(NewProductRequest product)
        {
            return Ok(await _productService.InsertProductAsync(product));
        }

        [HttpPut("{id}")]
        [SwaggerOperation("Update product")]
        [SwaggerResponse(StatusCodes.Status200OK, "Product updated successfully", typeof(string))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Product not found", typeof(string))]
        public async Task<IActionResult> Updateproduct(ProductUpdateRequest product, int id)
        {
            return Ok(await _productService.UpdateProductAsync(product, id));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delete product")]
        [SwaggerResponse(StatusCodes.Status200OK, "Product deleted successfully", typeof(string))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Product not found", typeof(string))]
        public async Task<IActionResult> Deleteproduct(int id)
        {
            return Ok(await _productService.DeleteProductAsync(id));
        }
    }
}
