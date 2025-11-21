using System.ComponentModel.DataAnnotations;

namespace LojaDeProdutos.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string? ImagePath { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
