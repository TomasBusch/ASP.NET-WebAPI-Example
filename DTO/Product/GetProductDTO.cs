using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAPI.DTO.Tag;
using WebAPI.DTO.Category;

namespace WebAPI.DTO.Product
{
    public class GetProductDTO
    {
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Range(0.01, 10000000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public IEnumerable<GetTagDTO>? Tags { get; set; }
        public required GetCategoryDTO Category { get; set; }
        public bool Discontinued { get; set; } = false;
    }
}
