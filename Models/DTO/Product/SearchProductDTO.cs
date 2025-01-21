using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTO.Product
{
    public class SearchProductDTO
    {
        public int Offset { get; set; } = 0;
        public int Count { get; set; } = 25;
        public int Name { get; set; }
        public string? Category { get; set; }
        public string? Tags { get; set; }
    }
}
