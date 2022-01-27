using Battleship.Application.Common.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Application.Interfaces
{
    public interface IGenericRepository<TEntity> : IGenericRepositoryBase
        //where TEntity : EntityBase
    {
        Task<TEntity> FindAsync(long id);

        Task UpdateAsync(TEntity entity, bool saveChanges = true);

        Task InsertAsync(TEntity entity, bool saveChanges = true);

        Task DeleteAsync(TEntity entity, bool saveChanges = true);

        Task DeleteAsync(long id, bool saveChanges = true);

        IQueryable<TEntity> Get();
    }
}
