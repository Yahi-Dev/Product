
using Microsoft.EntityFrameworkCore;
using Product.Core.Application.Interfaces.Repositories;
using Product.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace Product.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _entities;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        public virtual async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }


        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public virtual async Task<TEntity> GetEntityByIdAsync(int Id)
        {
            return await _entities.FindAsync(Id);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity, int Id)
        {
            var entry = await _context.Set<TEntity>().FindAsync(Id);
            _context.Entry(entry).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
