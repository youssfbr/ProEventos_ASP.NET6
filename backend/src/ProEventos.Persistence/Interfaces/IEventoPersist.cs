using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Interfaces
{
    public interface IEventoPersist
    {
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes);
    }
}