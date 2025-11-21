using LojaDeProdutos.DTO.Category;
using LojaDeProdutos.DTO.Product;
using LojaDeProdutos.Models;
using LojaDeProdutos.Models.Entities;
using LojaDeProdutos.Services.CategoryService;
using LojaDeProdutos.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryInterface _categoryInterface;

        public CategoryController(ICategoryInterface categoryInterface)
        {
            _categoryInterface = categoryInterface;
        }

        [HttpPost("createCategory")]
        public async Task<ActionResult<ResponseModel<Category>>> CreateCategory(DtoCreateCategory dtoCreateCategory)
        {
            var category = await _categoryInterface.CreateCategory(dtoCreateCategory);
            return Ok(category);
        }

        [HttpDelete("category/{categoryId}")]
        public async Task<ActionResult<ResponseModel<Category>>> DeleteCategoryById(int categoryId)
        {
            var category = await _categoryInterface.DeleteCategoryById(categoryId);
            return Ok(category);
        }

        [HttpPut("editCategory")]
        public async Task<ActionResult<ResponseModel<Category>>> EditProduct(DtoEditCategory dtoEditCategory)
        {
            var category = await _categoryInterface.EditCategory(dtoEditCategory);
            return Ok(category);
        }

        [HttpGet("listCategories")]
        public async Task<ActionResult<ResponseModel<List<Category>>>> ListCategories()
        {
            var categories = await _categoryInterface.ListCategories();
            return Ok(categories);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<ResponseModel<Product>>> FindCategoryById(int categoryId)
        {
            var category = await _categoryInterface.FindCategoryById(categoryId);
            return Ok(category);
        }

        [HttpGet("product/{productId}")]
        public async Task<ActionResult<ResponseModel<List<Product>>>> FindCategoryByProductId(int productId)
        {
            var product = await _categoryInterface.FindCategoryByProductId(productId);
            return Ok(product);
        }

    }
}
