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
        [HttpPost("NewGame")]
        public async Task<IActionResult> NewGame([FromBody] NewGameCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Put On both boards ship in Random places
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("SetShipsRandom")]
        public async Task<IActionResult> SetRandomShipInGame(long id)
        {
            var result = await Mediator.Send(new GameRandomShipCommand(id));
            return Ok(result);
        }

        /// <summary>
        /// Make a shot
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Shot")]
        public async Task<IActionResult> Shot([FromBody] ShotCommand command, long id)
        {
            if (command.GameId != id)
            {
                return BadRequest("GameId shuld be should be identical");
            }

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
