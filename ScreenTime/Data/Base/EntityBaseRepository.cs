using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace ScreenTime.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var results = await _context.Set<T>().ToArrayAsync();
            return results;
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (currnet, includeProperty) => currnet.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var results = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            return results;
        }

        public async Task Update(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
