using System.ComponentModel.DataAnnotations;

namespace Renodium.Api.Dtos
{
    public class CreateGameRequest
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;
        [StringLength(10000)]
        public string? Details { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [StringLength(2000)]
        public string? Image { get; set; }
        [StringLength(100)]
        [Required]
        public string Platform { get; set; } = null!;
    }
}
