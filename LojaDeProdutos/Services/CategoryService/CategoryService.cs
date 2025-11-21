using LojaDeProdutos.Context;
using LojaDeProdutos.DTO.Category;
using LojaDeProdutos.DTO.Product;
using LojaDeProdutos.Models;
using LojaDeProdutos.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaDeProdutos.Services.CategoryService
{
    public class CategoryService : ICategoryInterface
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Category>> CreateCategory(DtoCreateCategory dtoCreateCategory)
        {
            ResponseModel<Category> responseModel = new ResponseModel<Category>();

            try
            {
                var category = new Category

                {
                    Name = dtoCreateCategory.Name,
                    ImagePath = dtoCreateCategory.ImagePath,
                };

                _context.Add(category);
                await _context.SaveChangesAsync();

                responseModel.Data = category;
                responseModel.Message = "Category created successfully";
                responseModel.Status = true;
                return responseModel;
            }
            catch (Exception)
            {

                responseModel.Message = "Couldn't create category";
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<Category>> DeleteCategoryById(int categoryId)
        {
            ResponseModel<Category> responseModel = new ResponseModel<Category>();

            try
            {
                var category = await _context.Categories.FindAsync(categoryId);

                if (category == null)
                {
                    responseModel.Message = "Category not found on database";
                    responseModel.Status = false;
                    return responseModel;
                }

                _context.Remove(category);
                await _context.SaveChangesAsync();

                responseModel.Data = category;
                responseModel.Message = "Category removed successfully";
                responseModel.Status = true;
                return responseModel;
            }
            catch (Exception)
            {
                responseModel.Message = "Couldn't delete category";
                responseModel.Status = false; 
                return responseModel;
            }
        }

        public async Task<ResponseModel<Category>> EditCategory(DtoEditCategory dtoEditCategory)
        {
            ResponseModel<Category> responseModel = new ResponseModel<Category>();

            try
            {
                var category = await _context.Categories.FindAsync(dtoEditCategory.Id);

                if (category == null)
                {
                    responseModel.Message = "Couldn't find category on database.";
                    responseModel.Status = false;
                    return responseModel;
                }


                category.Name = dtoEditCategory.Name;
                category.ImagePath = dtoEditCategory.ImagePath;

                await _context.SaveChangesAsync();

                responseModel.Data = category;
                responseModel.Message = "Category edited successfully";
                responseModel.Status = true;
                return responseModel;
            }
            catch (Exception)
            {
                responseModel.Message = "Couldn't edit category.";
                responseModel.Status = false;
                return responseModel;
            }

        }

        public async Task<ResponseModel<Category>> FindCategoryById(int categoryId)
        {
            ResponseModel<Category> responseModel = new ResponseModel<Category>();

            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
            {

                responseModel.Message = "Category not found on database";
                responseModel.Status = false;
                return responseModel;
            }

            responseModel.Data = category;
            responseModel.Message = "Category has been found";
            responseModel.Status = true;
            return responseModel;
        }

        public async Task<ResponseModel<Category>> FindCategoryByProductId(int productId)
        {
            ResponseModel<Category> responseModel = new ResponseModel<Category>();


            try {
                var product = await _context.Products.Include(p => p.Category)
                .FirstOrDefaultAsync(product => product.Id == productId);

                if (product == null)
                {
                    responseModel.Message = "Product not found on database";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = product.Category;
                responseModel.Message = "Category found";
                responseModel.Status = true;
                return responseModel;

            }
            catch (Exception)
            {
                responseModel.Message = "Couldn't find category";
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<Category>>> ListCategories()
        {
            ResponseModel<List<Category>> responseModel = new ResponseModel<List<Category>>();

            try
            {
                var categories = await _context.Categories.Include(c => c.Products).ToListAsync();

                responseModel.Data = categories;
                responseModel.Message = "Categories collected successfully";
                responseModel.Status = true;
                return responseModel;
            }
            catch (Exception)
            {
                responseModel.Message = "Couldn't find categories";
                responseModel.Status = false;
                return responseModel;
            }
        }
    }
}
