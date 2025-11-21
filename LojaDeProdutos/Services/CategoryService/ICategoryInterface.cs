using LojaDeProdutos.DTO.Category;
using LojaDeProdutos.Models;
using LojaDeProdutos.Models.Entities;

namespace LojaDeProdutos.Services.CategoryService
{
    public interface ICategoryInterface
    {
        Task<ResponseModel<List<Category>>> ListCategories();
        Task<ResponseModel<Category>> FindCategoryById(int categoryId);
        Task<ResponseModel<Category>> FindCategoryByProductId(int productId);
        Task<ResponseModel<Category>> CreateCategory (DtoCreateCategory dtoCreateCategory);
        Task<ResponseModel<Category>> EditCategory (DtoEditCategory dtoEditCategory);
        Task<ResponseModel<Category>> DeleteCategoryById(int categoryId);
    }
}
