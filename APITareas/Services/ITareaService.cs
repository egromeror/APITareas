using APITareas.Models;

namespace APITareas.Services
{
    public interface ITareaService
    {
        List<Tarea> ObtenerTodos();
        Tarea ObtenerPorId(int id);
        Tarea CrearTarea(Tarea tarea);
        Tarea ActualizarTarea(int id, Tarea tarea);
        bool EliminarTarea(int id);
    }
}
