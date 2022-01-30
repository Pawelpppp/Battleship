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
    }
}
