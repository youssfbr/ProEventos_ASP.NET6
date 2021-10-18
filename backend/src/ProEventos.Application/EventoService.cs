using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        private readonly IMapper _mapper;

        public EventoService(IGeralPersist geralPersist, 
                             IEventoPersist eventoPersist, 
                             IMapper mapper)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
            _mapper = mapper;
        }
        public async Task<EventoDto> AddEvento(EventoDto dto)
        {
            try
            {
                var evento = _mapper.Map<Evento>(dto);

                 _geralPersist.Add<Evento>(evento);

                 if (await _geralPersist.SaveChangesAsync())
                 {
                     var eventoRetorno = await _eventoPersist.GetEventoByIdAsync(evento.Id, false);
                     
                     return _mapper.Map<EventoDto>(eventoRetorno);
                 }
                  
                 return null;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int id, EventoDto dto)
        {
            try
            {                
                var evento = await _eventoPersist.GetEventoByIdAsync(id, false);
                if (evento == null) return null;

                dto.Id = evento.Id;

                _mapper.Map(dto, evento);


                _geralPersist.Update<Evento>(evento);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await _eventoPersist.GetEventoByIdAsync(evento.Id, false);
                    
                    return _mapper.Map<EventoDto>(eventoRetorno);
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

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes)
        {
            try
            {
                 var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                 
                 var dtos = _mapper.Map<EventoDto[]>(eventos);

                 return dtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);     

                var dtos = _mapper.Map<EventoDto[]>(eventos);

                return dtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int id, bool includePalestrantes)
        {
            try
            {
                 var evento = await _eventoPersist.GetEventoByIdAsync(id, includePalestrantes);
                 if (evento == null) return null;

                 var dto = _mapper.Map<EventoDto>(evento);
                 
                 return dto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}