using Battleship.Application.Command.Battleship;
using Battleship.Application.Queries.Battleship;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Battleship
{
    public class BattleshipController : ApiControllerBase
    {

        [HttpGet()]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetAllBattleshipsQuery());
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> SetShip([FromBody] SetShipCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
