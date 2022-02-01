using Battleship.Application.Command.Battleship;
using Battleship.Application.Command.Board;
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

        /// <summary>
        /// Set ships that on bord in random places
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("/setAllShipsOnBoard")]
        public async Task<IActionResult> SetShipsInRandomPlaces(long id)
        {
            var result = await Mediator.Send(new SetShipsInRandomPlacesCommand(id));
            return Ok(result);
        }
    }
}
