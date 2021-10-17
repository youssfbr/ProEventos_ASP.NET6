using ProEventos.Domain.Models;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento model);
        Task<Evento> UpdateEvento(int id, Evento model);
        Task<bool> RemoveEvento(int id);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes);

    }
}