using Battleship.Application.Interfaces;
using Battleship.Domain.Entities;
using Battleship.Infrastructure.Persistence;

namespace Battleship.Infrastructure.Repositories
{
    internal class BoardRepository : GenericRepository<Board>, IBoardRepository
    {
        public BoardRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
