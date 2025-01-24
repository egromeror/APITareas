using Microsoft.AspNetCore.Mvc;
using APITareas.Models;
using APITareas.Services;
using System.Collections.Generic;

namespace APITareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _TareaService;

        public TareaController(ITareaService TareaService)
        {
            _TareaService = TareaService;
        }

        // GET api/Tarea
        
        [HttpGet]
        public ActionResult<IEnumerable<Tarea>> Get()
        {
            return Ok(_TareaService.ObtenerTodos());
        }

        // GET api/Tarea/5
        
        [HttpGet("{id}")]
        public ActionResult<Tarea> Get(int id)
        {
            var Tarea = _TareaService.ObtenerPorId(id);
            if (Tarea == null)
            {
                return NotFound();
            }
            return Ok(Tarea);
        }

        // GET api/Tarea/Estado/5
        [HttpGet("[action]/{idestado}")]
        public ActionResult<Tarea> Estado(int idestado)
        {
            var Tarea = _TareaService.ObtenerPorEstado(idestado);
            if (Tarea == null)
            {
                return NotFound();
            }
            return Ok(Tarea);
        }

        // POST api/Tarea
        
        [HttpPost]
        public ActionResult<Tarea> Post([Bind("Id,Nombre,Descripcion,Prioridad,IdEstado")] Tarea tarea)
        {
            var nuevoTarea = _TareaService.CrearTarea(tarea);
            return CreatedAtAction(nameof(Get), new { id = nuevoTarea.Id }, nuevoTarea);
        }

        // PUT api/Tarea/5
        
        [HttpPut("{id}")]
        public ActionResult<Tarea> Put(int id, [Bind("Id,Nombre,Descripcion,Prioridad,IdEstado")] Tarea tarea)
        {
            var TareaActualizado = _TareaService.ActualizarTarea(id, tarea);
            if (TareaActualizado == null)
            {
                return NotFound();
            }
            return Ok(TareaActualizado);
        }

        // DELETE api/Tarea/5
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var exito = _TareaService.EliminarTarea(id);
            if (!exito)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
