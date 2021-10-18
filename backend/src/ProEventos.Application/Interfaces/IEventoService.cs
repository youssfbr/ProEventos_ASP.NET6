using ProEventos.Application.Dtos;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<EventoDto> AddEvento(EventoDto dto);
        Task<EventoDto> UpdateEvento(int id, EventoDto dto);
        Task<bool> RemoveEvento(int id);

        Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes);
        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<EventoDto> GetEventoByIdAsync(int id, bool includePalestrantes);

    }
}