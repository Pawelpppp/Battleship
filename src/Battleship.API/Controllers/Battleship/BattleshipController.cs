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
    }
}
