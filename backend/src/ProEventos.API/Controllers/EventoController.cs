using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain.Models;
using ProEventos.Application.Interfaces;
using ProEventos.API.Dtos;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly IEventoService _eventoService;   

    public EventoController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
             var eventos = await _eventoService.GetAllEventosAsync(true);

             var eventosRetorno = new List<EventoDto>();

             foreach (var evento in eventos)
             {
                 eventosRetorno.Add(new EventoDto() {
                     Id = evento.Id,
                     Local = evento.Local,
                     Tema = evento.Tema,
                     QtsPessoas = evento.QtsPessoas,
                     ImagemURL = evento.ImagemURL,
                     Telefone = evento.Telefone,
                     Email = evento.Email
                 });
             }

             return Ok(eventosRetorno) ;
        }
        catch (Exception ex)
        {            
            return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar Eventos. {ex.Message}");
        }
    }

    [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetAllByTema(string tema)
    {
        try
        {
             var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);

             return Ok(eventos);
        }
        catch (Exception ex)
        {            
            return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar Eventos pelo tema. {ex.Message}");
        }        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
             var evento = await _eventoService.GetEventoByIdAsync(id, true);

             return evento == null ? 
                NotFound("Evento por id não encontrado.") :
                Ok(evento);
        }
        catch (Exception ex)
        {            
            return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar Evento por id. {ex.Message}");
        }        
    }

    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
          try
        {
             var evento = await _eventoService.AddEvento(model);

             if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");
             
             return Created($"api/evento/{evento.Id}", evento);             
        }
        catch (Exception ex)
        {            
            return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar adicionar Evento. {ex.Message}");
        } 
    }           

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
        try
        {
            var evento = await _eventoService.UpdateEvento(id, model);

            return evento == null? 
                NotFound("Evento não encontrado.") :
                Ok(evento);
        }
        catch (Exception ex)
        {            
            return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar atualizar Evento. {ex.Message}");
        }       
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        try
        {
             return await _eventoService.RemoveEvento(id) ?
                NoContent() :
                NotFound("Evento não encontrado.");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar deletar Evento. {ex.Message}");
        }
    }

}
