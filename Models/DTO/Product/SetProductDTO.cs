using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAPI.Models.DTO.Tag;
using WebAPI.Models.DTO.Category;

namespace WebAPI.Models.DTO.Product
{
    public class SetProductDTO
    {
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Range(0.01, 10000000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public IEnumerable<SetTagDTO>? Tags { get; set; }
        public required SetCategoryDTO Category { get; set; }
        public bool Discontinued { get; set; } = false;
    }
}
