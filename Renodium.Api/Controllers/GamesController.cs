using Microsoft.AspNetCore.Mvc;
using Renodium.Api.Dtos;

namespace Renodium.Api.Controllers {
    [ApiController]
    [Route("[controller]/[action]")]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        public List<GameDto> GetGames() {
            GameDto firstGame = new GameDto
            {
                Id = 1,
                Title = "GTA 5",
                Price = 9899,
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcStFVNyU8sjMhLuy1Y89uDEgv6JQtY9ghwbfA&s",
                Platform = "pc",
                Details = "Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar North and published by Rockstar Games. It is the seventh main entry in the Grand Theft Auto series, following 2008's Grand Theft Auto IV, and the fifteenth instalment overall. Set within the fictional state of San Andreas, based on Southern California, the single-player story follows three protagonists—retired bank robber Michael De Santa (Ned Luke), street gangster Franklin Clinton (Shawn Fonteno), and drug dealer and gunrunner Trevor Philips (Steven Ogg)—and their attempts to commit heists while under pressure from a corrupt government agency and powerful criminals. Players freely roam San Andreas's open world countryside and fictional city of Los Santos, based on Los Angeles.",
            };
            GameDto secondGame = new GameDto
            {
                Id = 2,
                Title = "Phasmaphobia",
                Price = 5500,
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/739630/c227a2855aba60f3657bc0c3a46515b8c41fb2b6/header.jpg?t=1773761698",
                Platform = "pc",
                Details = "Phasmophobia is a paranormal horror game developed and published by British indie game studio Kinetic Games (based in Southampton). The game became available in early access for Microsoft Windows with virtual reality support in September 2020. In the game, one to four players take on the role of ghost hunters who work to complete a contract where they must identify the type of ghost haunting a designated site and complete other optional objectives.",
            };
            GameDto thirdGame = new GameDto
            {
                Id = 3,
                Title = "Split Fiction",
                Price = 12599,
                Image = "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2001120/header.jpg?t=1763484567",
                Platform = "ps",
                Details = "Split Fiction is a 2025 action-adventure game developed by Hazelight Studios and published by Electronic Arts. As a cooperative multiplayer-only game, it follows authors Mio Hudson and Zoe Foster after they become imprisoned in the world of their stories when they are connected to a machine designed to steal creative ideas.",
            };
            var result = new List<GameDto>() { firstGame, secondGame, thirdGame };
            return result;
        }
    }
}
