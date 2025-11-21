using LojaDeProdutos.DTO.Product;
using LojaDeProdutos.Models;
using LojaDeProdutos.Models.Entities;

namespace LojaDeProdutos.Services.ProductService
{
    public interface IProductInterface
    {
        Task<ResponseModel<List<Product>>> ListProducts();
        Task<ResponseModel<Product>> FindProductById(int productId);
        Task<ResponseModel<List<Product>>> FindProductsByCategoryId(int categoryId);
        Task<ResponseModel<Product>> CreateProduct(DtoCreateProduct dtoCreateProduct);
        Task<ResponseModel<Product>> EditProduct(DtoEditProduct dtoEditProduct);
        Task<ResponseModel<Product>> DeleteProductById(int productId);

    }
}
