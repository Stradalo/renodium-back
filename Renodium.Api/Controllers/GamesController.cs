using Microsoft.AspNetCore.Mvc;
using Renodium.Api.Dtos;
using Renodium.Api.Interfaces;
using Renodium.Api.Services;

namespace Renodium.Api.Controllers {
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
            var result = await _gamesService.GetGames();
            return result;
        }

        [HttpGet("{gameId}")]
        public async Task<ActionResult<GameDto>> GetGameById(int gameId)
        {
            var result = await _gamesService.GetGameById(gameId);
            if (result == null) {
                return NotFound();
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<GameDto>> CreateGame(CreateGameRequest createGameRequest)
        {
            var result = await _gamesService.CreateGame(createGameRequest);
            return CreatedAtAction(
                nameof(GetGameById),
                new { gameId = result.Id },
                result
            );
        }
    }
}
