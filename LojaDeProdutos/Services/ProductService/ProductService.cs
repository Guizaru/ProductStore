using LojaDeProdutos.Context;
using LojaDeProdutos.DTO.Product;
using LojaDeProdutos.Models;
using LojaDeProdutos.Models.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace LojaDeProdutos.Services.ProductService
{
    public class ProductService : IProductInterface
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Product>> CreateProduct(DtoCreateProduct dtoCreateProduct)
        {
            ResponseModel<Product> responseModel = new ResponseModel<Product>();

            try
            {
                var product = new Product()
                {
                    Name = dtoCreateProduct.Name,
                    Description = dtoCreateProduct.Description,
                    Price = dtoCreateProduct.Price,
                    ImagePath = dtoCreateProduct.ImagePath,
                    Available = dtoCreateProduct.Available,
                    CategoryId = dtoCreateProduct.CategoryId,
                };

                _context.Add(product);
                await _context.SaveChangesAsync();

                responseModel.Data = product;
                responseModel.Message = "Product has been created successfully";
                responseModel.Status = true;
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = "Couldn't create product.";
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<Product>> DeleteProductById(int productId)
        {
            ResponseModel<Product> responseModel = new ResponseModel<Product>();

            try
            {
                var product = await _context.Products.FindAsync(productId);

                if (product == null)
                {
                    responseModel.Message = "Couldn't find product on database.";
                    responseModel.Status = false;
                    return responseModel;
                }
                    _context.Remove(product);
                    await _context.SaveChangesAsync();

                    responseModel.Data = product;
                    responseModel.Message = "Product have been deleted successfully";
                    responseModel.Status = true;
                    return responseModel;
            }
            catch (Exception)
            {
                responseModel.Message = "Couldn't delete product.";
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<Product>> EditProduct(DtoEditProduct dtoEditProduct)
        {
            ResponseModel<Product> responseModel = new ResponseModel<Product>();

            try
            {
                var product = await _context.Products.FindAsync(dtoEditProduct.Id);

                if (product == null)
                {
                    responseModel.Message = "Couldn't find product on database.";
                    responseModel.Status = false;
                    return responseModel;
                }

                product.Name = dtoEditProduct.Name;
                product.Description = dtoEditProduct.Description;
                product.Price = dtoEditProduct.Price;
                product.ImagePath = dtoEditProduct.ImagePath;
                product.Available = dtoEditProduct.Available;
                product.CategoryId = dtoEditProduct.CategoryId;

                await _context.SaveChangesAsync();

                responseModel.Data = product;
                responseModel.Message = "Product edited successfully";
                responseModel.Status = true;
                return responseModel;
            }
            catch (Exception)
            {
                responseModel.Message = "Couldn't edit product.";
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<Product>> FindProductById(int productId)
        {
            ResponseModel<Product> responseModel = new ResponseModel<Product>();

            try
            {
                var product = await _context.Products.FindAsync(productId);

                if (product == null)
                {
                    responseModel.Message = "Couldn't find product on database.";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = product;
                responseModel.Message = "Product found";
                responseModel.Status = true;
                return responseModel;
            }
            catch (Exception)
            {
                responseModel.Message = "Couldn't find product.";
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<Product>>> FindProductsByCategoryId(int categoryId)
        {
            ResponseModel<List<Product>> responseModel = new ResponseModel<List<Product>>();

            try
            {

                var category = await _context.Categories.Include(c => c.Products)
                    .FirstOrDefaultAsync(category => category.Id == categoryId);

                if (category == null)
                {
                    responseModel.Message = "Couldn't find category on database.";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = category.Products;
                responseModel.Message = "Products found successfully";
                responseModel.Status = true;
                return responseModel;
            }
            catch (Exception)
            {
                responseModel.Message = "Couldn't find products.";
                responseModel.Status = false;
                return responseModel;
            }
        }
        public async Task<ResponseModel<List<Product>>> ListProducts()
        {
            ResponseModel<List<Product>> responseModel = new ResponseModel<List<Product>>();

            try
            {
                var products = await _context.Products
                            .Include(p => p.Category)
                            .ToListAsync();

                responseModel.Data = products;
                responseModel.Message = "Products available";
                responseModel.Status = true;
                return responseModel;
            }
            catch (Exception)
            {
                responseModel.Message = "Couldn't collect products.";
                responseModel.Status = false;
                return responseModel;
            }
        }
    }
}
