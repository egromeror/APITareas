using Microsoft.EntityFrameworkCore;
using APITareas.Models;
using APITareas.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITareas.Services
{
    public class TareaService: ITareaService
    {
        private readonly AppDbContext _context;

        public TareaService(AppDbContext context)
        {
            _context = context;
        }

        public List<Tarea> ObtenerTodos()
        {
            return _context.Tarea.ToList();
        }

        public Tarea ObtenerPorId(int id)
        {
            return _context.Tarea.FirstOrDefault(p => p.Id == id);
        }

        public Tarea CrearTarea(Tarea Tarea)
        {
            _context.Tarea.Add(Tarea);
            _context.SaveChanges();
            return Tarea;
        }

        public Tarea ActualizarTarea(int id, Tarea Tarea)
        {
            var TareaExistente = ObtenerPorId(id);
            if (TareaExistente == null) return null;

            TareaExistente.Nombre = Tarea.Nombre;
            TareaExistente.Descripcion = Tarea.Descripcion;
            TareaExistente.Prioridad = Tarea.Prioridad;
            TareaExistente.IdEstado = Tarea.IdEstado;

            _context.SaveChanges();
            return TareaExistente;
        }

        public bool EliminarTarea(int id)
        {
            var Tarea = ObtenerPorId(id);
            if (Tarea == null) return false;

            _context.Tarea.Remove(Tarea);
            _context.SaveChanges();
            return true;
        }
    }
}