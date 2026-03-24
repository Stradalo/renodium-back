using Microsoft.EntityFrameworkCore;
using Renodium.Api.Data;
using Renodium.Api.Dtos;
using Renodium.Api.Interfaces;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Renodium.Api.Services
{
    public class GamesService : IGamesService
    {
        private readonly AppDbContext _db;
        public GamesService(AppDbContext db) { 
            _db = db;
        }

        public async Task<List<GameDto>> GetGames()
        {
            List<GameDto> gameList = await _db.Games
                .Select(g => new GameDto
                {
                    Id = g.Id,
                    Title = g.Title,
                    Price = g.Price,
                    Details = g.Details,
                    Image = g.Image,
                    Platform = g.Platform,
                })
                .ToListAsync();
            return gameList;
        }

        public async Task<GameDto?> GetGameById(int gameId) 
        {
            GameDto? result = await _db.Games
                .AsNoTracking()
                .Where(g => g.Id == gameId)
                .Select(g => new GameDto
                {
                    Id = g.Id,
                    Title = g.Title,
                    Price = g.Price,
                    Details = g.Details,
                    Image = g.Image,
                    Platform = g.Platform,
                })
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
