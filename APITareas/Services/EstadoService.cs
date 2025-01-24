using Microsoft.EntityFrameworkCore;
using APITareas.Models;
using APITareas.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITareas.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly AppDbContext _context;

        public EstadoService(AppDbContext context)
        {
            _context = context;
        }

        public List<Estado> ObtenerTodos()
        {
            return _context.VW_TAREAS_POR_ESTADO.ToList();
        }
    }
}