using Battleship.Application.Command.Game;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Game
{
    public class GameController : ApiControllerBase
    {
        /// <summary>
        ///  Start new Game with provided board-id's or crete new empty boards
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> NewGame([FromBody] NewGameCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
