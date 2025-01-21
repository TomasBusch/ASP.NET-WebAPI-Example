using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
        public string? Description {  get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Range(0.01, 10000000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public IEnumerable<Tag>? Tags { get; set; }
        public required Category Category { get; set; }
        public bool Discontinued { get; set; } = false;

        public IEnumerable<WishList>? wishLists { get; set; }
    }
}
