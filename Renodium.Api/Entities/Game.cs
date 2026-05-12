namespace Renodium.Api.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public string? Details { get; set; }
        public string? Image { get; set; }
        public string Platform { get; set; } = string.Empty;
    }
}
