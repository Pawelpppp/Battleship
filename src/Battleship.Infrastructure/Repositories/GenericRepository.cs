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

        public virtual async Task UpdateAsync(TEntity entity, bool saveChanges = true)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            if (saveChanges)
            {
                await SaveChangesAsync();
            }
        }

        public virtual async Task InsertAsync(TEntity entity, bool saveChanges = true)
        {
            _dbset.Add(entity);
            if (saveChanges)
            {
                await SaveChangesAsync();
            }
        }

        public virtual async Task DeleteAsync(TEntity entity, bool saveChanges = true)
        {
            if (entity == null)
            {
                return;
            }

            if (_entities.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }

            _dbset.Remove(entity);
            if (saveChanges)
            {
                await SaveChangesAsync();
            }
        }

        public virtual async Task DeleteAsync(long id, bool saveChanges = true)
        {
            await DeleteAsync(await FindAsync(id), saveChanges);
        }

        protected async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // log an exception
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                // log an exception
                throw ex;
            }
        }
    }
}
