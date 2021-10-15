namespace ProEventos.API.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string? Local { get; set; }
        public string? DataEvento { get; set; }
        public string? Tema { get; set; }
        public int QtsPessoas { get; set; } 
        public string? Lote { get; set; }
        public string? ImagemURL { get; set; }
    }
}