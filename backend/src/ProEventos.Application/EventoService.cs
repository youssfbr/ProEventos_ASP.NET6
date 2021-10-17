using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                 _geralPersist.Add<Evento>(model);
                 if (await _geralPersist.SaveChangesAsync())
                 {
                     return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                 }
                 return null;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int id, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(id, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;                 
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveEvento(int id)
        {
             try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(id, false);
                if (evento == null) return false; // throw new Exception("Evento para delete não encontrado.")               

                _geralPersist.Remove<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();                    
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            try
            {
                 var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                 //if (eventos == null) return null;
                 return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            try
            {
                 return await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);                       
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes)
        {
            try
            {
                 var evento = await _eventoPersist.GetEventoByIdAsync(id, includePalestrantes);
                 if (evento == null) return null;
                 
                 return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}