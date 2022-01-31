using Battleship.Application.Command;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Board
{
    public class BoardController : ApiControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> CreateBoard()
        {
            var result = await Mediator.Send(new CreateBordCommand());
            return Ok(result);
        }

        [HttpPost("/setAllShipsOnBoard")]
        public async Task<IActionResult> SetShipsInRandomPlaces(long id)
        {
            var result = await Mediator.Send(new SetShipsInRandomPlacesCommand(id));
            return Ok(result);
        }
    }
}
