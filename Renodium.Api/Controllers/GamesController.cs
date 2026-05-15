using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Renodium.Api.Dtos;
using Renodium.Api.Interfaces;

namespace Renodium.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gamesService;
        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GameDto>>> GetGames()
        {
            var result = await _gamesService.GetGamesAsync();
            return Ok(result);
        }

        [HttpGet("{gameId}")]
        public async Task<ActionResult<GameDto>> GetGameById(int gameId)
        {
            var result = await _gamesService.GetGameByIdAsync(gameId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GameDto>> CreateGame(CreateGameRequest createGameRequest)
        {
            var result = await _gamesService.CreateGameAsync(createGameRequest);
            return CreatedAtAction(
                nameof(GetGameById),
                new { gameId = result.Id },
                result
            );
        }

        [HttpPut("{gameId}")]
        [Authorize]
        public async Task<ActionResult<GameDto>> UpdateGame(int gameId, UpdateGameRequest updateGameRequest)
        {
            var result = await _gamesService.UpdateGameAsync(gameId, updateGameRequest);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{gameId}")]
        [Authorize]
        public async Task<ActionResult> DeleteGame(int gameId)
        {
            var result = await _gamesService.DeleteGameAsync(gameId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
