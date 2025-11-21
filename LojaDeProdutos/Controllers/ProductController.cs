using LojaDeProdutos.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductInterface _productInterface;

        public ProductController(IProductInterface productInterface)
        {
            _productInterface = productInterface;
        }


    }
}
