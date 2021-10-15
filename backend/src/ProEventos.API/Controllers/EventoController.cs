using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{ 
    public EventoController()
    {        
    }

    [HttpGet]
    public Evento Get()
    {
        return new Evento() {
            Id = 1,
            Tema = "Angular e .NET 6",
            Local = "Fortaleza",
            Lote = "1o lote",
            QtsPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString()  
        };
    }
}
