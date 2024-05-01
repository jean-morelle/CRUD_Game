using CRUD_Game.Models;
using CRUD_Game.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Game.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameServices gameServices;

        public GameController(IGameServices gameServices)
        {
            this.gameServices = gameServices;
        }

        [HttpPost]

        public async Task <IActionResult>AddGame(Game game)
        {
            var addGame = await gameServices.AddGame(game);
            return Ok(addGame);
        }

        [HttpGet("id")]

        public async Task<IActionResult> GetGameId(int id)
        {
            var game = await gameServices.GetByIdAsync(id);
            return Ok(game);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> EditGame(int id,Game game)
        {
            var UpdateGame = await gameServices.EditGame(id, game);
            return Ok(UpdateGame);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteGame(int id)
        {
            var result = await gameServices.DeleteGame(id);
            return Ok(result);
        }

    }
}
