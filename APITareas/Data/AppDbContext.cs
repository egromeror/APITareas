using Microsoft.EntityFrameworkCore;
using APITareas.Models;

namespace APITareas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tarea> Tarea { get; set; }
    }
}
