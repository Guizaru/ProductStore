using System.ComponentModel.DataAnnotations;

namespace LojaDeProdutos.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [StringLength(400)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public bool Available { get; set; } = true;
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
