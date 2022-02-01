using System.Collections.Generic;

namespace Battleship.Application.Command.Battleship
{
    public class ShotResponse
    {
        public List<string> Response { get; set; }
        public ShotResponse(string response)
        {
            Response = new List<string>();
            Response.Add(response);
        }
    }

}
