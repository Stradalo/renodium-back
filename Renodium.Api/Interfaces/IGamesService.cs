using Renodium.Api.Dtos;

namespace Renodium.Api.Interfaces
{
    public interface IGamesService
    {
        Task<List<GameDto>> GetGamesAsync();
        Task<GameDto?> GetGameByIdAsync(int id);
        Task<GameDto> CreateGameAsync(CreateGameRequest createGameRequest);
        Task<GameDto?> UpdateGameAsync(int gameId, UpdateGameRequest updateGameRequest);
        Task<bool> DeleteGameAsync(int gameId);
    }
}
