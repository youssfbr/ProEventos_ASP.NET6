namespace ProEventos.Persistence.Interfaces
{
    public interface IGeralPersist
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Remove<T>(T entity) where T: class;
        void RemoveRange<T>(T[] entityArray) where T: class;
        Task<bool> SaveChangesAsync();        
    }
}