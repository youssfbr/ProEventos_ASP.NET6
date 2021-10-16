using ProEventos.Persistence.Data;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        public readonly ProEventosContext _context;
        public GeralPersist(ProEventosContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void RemoveRange<T>(T[] entityArray) where T : class
        {
            _context.Remove(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}