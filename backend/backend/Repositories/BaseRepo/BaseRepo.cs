using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.BaseRepo
{
    public class BaseRepo<T> : IBaseRepo<T>
        where T : BaseModel, new()
    {
        protected readonly NoteContext _context;
        protected readonly ILogger<BaseRepo<T>> _logger;

        public BaseRepo(NoteContext context, ILogger<BaseRepo<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<T?> CreateAsync(T create)
        {
            await _context.Set<T>().AddAsync(create);
            await _context.SaveChangesAsync();
            return create;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity is null)
            {
                return false;
            }
            else
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public virtual async Task<ICollection<T>> GetAllAsync(QueryOptions options)
        {
            var query = _context.Set<T>().AsNoTracking();

            query.Skip(options.Skip).Take(options.Limit);
            return await query.ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> UpdateAsync(int id, T request)
        {
            var item = await GetAsync(id);
            request.Id = item!.Id;
            _context.Entry(item).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
