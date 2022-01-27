using Battleship.Application.Interfaces;
using Battleship.Domain.Entities;
using Battleship.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Infrastructure.Repositories
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity>
     where TEntity : EntityBase
    {
        protected readonly DbSet<TEntity> _dbset;
        private readonly DbContext _entities;

        public GenericRepository(ApplicationDbContext context)
        {
            _entities = context;
            _dbset = _entities.Set<TEntity>();
        }

        //do not use
        public virtual IQueryable<TEntity> Get()
        {
            return _dbset;
        }

        public virtual async Task<TEntity> FindAsync(long id)
        {
            return await Get().SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task DeleteAsync(TEntity entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id, bool saveChanges = true)
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
