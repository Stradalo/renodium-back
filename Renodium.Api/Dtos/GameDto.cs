namespace Renodium.Api.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? Details { get; set; }
        public string? Image {  get; set; }
        public string? Platform { get; set; }

    }
}
