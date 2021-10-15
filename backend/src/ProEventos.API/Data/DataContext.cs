using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;

namespace ProEventos.API.Data
{
    public class DataContext : DbContext
    {        
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");           
        }   

    }
}