using Battleship.Application.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Infrastructure.Repositories
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity>
    // where TEntity : EntityBase
    {
        public Task DeleteAsync(TEntity entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(TEntity entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
