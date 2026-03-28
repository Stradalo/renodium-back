using System.ComponentModel.DataAnnotations;

namespace Renodium.Api.Dtos
{
    public class UpdateGameRequest
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;
        public string? Details { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public string? Image { get; set; }
        [StringLength(200)]
        [Required]
        public string Platform { get; set; } = null!;
    }
}
