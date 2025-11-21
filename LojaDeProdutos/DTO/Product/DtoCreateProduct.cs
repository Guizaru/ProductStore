namespace LojaDeProdutos.DTO.Product
{
    public class DtoCreateProduct
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public bool Available { get; set; } = true;
        public int CategoryId { get; set; }
    }
}
