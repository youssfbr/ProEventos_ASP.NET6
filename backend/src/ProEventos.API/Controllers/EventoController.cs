using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{ 
    private IEnumerable<Evento> _eventos = new Evento[] 
    {
        new Evento() 
        {
            Id = 1,
            Tema = "Angular e .NET 6",
            Local = "Fortaleza",
            Lote = "1o lote",
            QtsPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString(),
            ImagemURL = "foto1.png"  
        },
        new Evento() 
        {
            Id = 2,
            Tema = ".NET 6 e suas novidades",
            Local = "Caucaia",
            Lote = "2o lote",
            QtsPessoas = 350,
            DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
            ImagemURL = "foto2.png"  
        }
    };

    public EventoController()
    {        
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _eventos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _eventos.Where(x => x.Id == id);
    }

}
