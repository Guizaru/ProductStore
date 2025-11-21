using LojaDeProdutos.DTO.Product;
using LojaDeProdutos.Models;
using LojaDeProdutos.Models.Entities;
using LojaDeProdutos.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductInterface _productInterface;

        public ProductController(IProductInterface productInterface)
        {
            _productInterface = productInterface;
        }

        [HttpPost("createProduct")]
        public async Task<ActionResult<ResponseModel<Product>>> CreateProduct (DtoCreateProduct dtoCreateProduct)
        {
            var product = await _productInterface.CreateProduct(dtoCreateProduct);
            return Ok(product);
        }

        [HttpDelete("product/{productId}")]
        public async Task<ActionResult<ResponseModel<Product>>> DeleteProduct(int productId)
        {
            var product = await _productInterface.DeleteProductById(productId);
            return Ok(product);
        }

        [HttpPut("editProduct")]
        public async Task<ActionResult<ResponseModel<Product>>> EditProduct(DtoEditProduct dtoEditProduct)
        {
            var product = await _productInterface.EditProduct(dtoEditProduct);
            return Ok(product);
        }

        [HttpGet("listProducts")]
        public async Task<ActionResult<ResponseModel<List<Product>>>> ListProducts()
        {
            var products = await _productInterface.ListProducts();
            return Ok(products);
        }

        [HttpGet("product/{productId}")]
        public async Task<ActionResult<ResponseModel<Product>>> FindProductById(int productId)
        {
            var product = await _productInterface.FindProductById(productId);
            return Ok(product);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<ResponseModel<List<Product>>>> FindProductsByCategoryId(int categoryId)
        {
            var product = await _productInterface.FindProductsByCategoryId(categoryId);
            return Ok(product);
        }

    }
}
