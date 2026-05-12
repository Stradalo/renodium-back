using Microsoft.EntityFrameworkCore;
using Renodium.Api.Data;
using Renodium.Api.Dtos;
using Renodium.Api.Entities;
using Renodium.Api.Interfaces;

namespace Renodium.Api.Services
{
    public class GamesService : IGamesService
    {
        private readonly AppDbContext _db;
        public GamesService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<GameDto>> GetGamesAsync()
        {
            List<GameDto> gameList = await _db.Games
                .AsNoTracking()
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

        public async Task<GameDto?> GetGameByIdAsync(int gameId)
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

        public async Task<GameDto> CreateGameAsync(CreateGameRequest request)
        {
            var newGame = new Game
            {
                Title = request.Title,
                Price = request.Price,
                Details = request.Details,
                Image = request.Image,
                Platform = request.Platform,
            };

            _db.Games.Add(newGame);
            await _db.SaveChangesAsync();

            GameDto result = new GameDto
            {
                Id = newGame.Id,
                Title = newGame.Title,
                Price = newGame.Price,
                Details = newGame.Details,
                Image = newGame.Image,
                Platform = newGame.Platform
            };

            return result;
        }

        public async Task<GameDto?> UpdateGameAsync(int gameId, UpdateGameRequest request)
        {
            var game = await _db.Games.FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null)
            {
                return null;
            }

            game.Title = request.Title;
            game.Price = request.Price;
            game.Details = request.Details;
            game.Image = request.Image;
            game.Platform = request.Platform;

            await _db.SaveChangesAsync();

            GameDto result = new GameDto
            {
                Id = game.Id,
                Title = game.Title,
                Price = game.Price,
                Details = game.Details,
                Image = game.Image,
                Platform = game.Platform
            };

            return result;
        }

        public async Task<bool> DeleteGameAsync(int gameId)
        {
            var game = await _db.Games.FirstOrDefaultAsync(g => g.Id == gameId);
            if (game == null)
            {
                return false;
            }

            _db.Games.Remove(game);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
