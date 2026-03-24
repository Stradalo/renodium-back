using Renodium.Api.Dtos;

namespace Renodium.Api.Interfaces
{
    public interface IGamesService
    {
        Task<List<GameDto>> GetGames();
        Task<GameDto?> GetGameById(int id);
    }
}
