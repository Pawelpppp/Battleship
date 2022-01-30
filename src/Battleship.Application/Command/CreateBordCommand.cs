using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Application.Command
{
    public class CreateBordCommand : IRequest<long>
    {
    }
}
