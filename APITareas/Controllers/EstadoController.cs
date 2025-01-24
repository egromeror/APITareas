using Microsoft.AspNetCore.Mvc;
using APITareas.Models;
using APITareas.Services;
using System.Collections.Generic;

namespace APIEstados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _EstadoService;

        public EstadoController(IEstadoService EstadoService)
        {
            _EstadoService = EstadoService;
        }

        // GET api/Estado
        
        [HttpGet]
        public ActionResult<IEnumerable<Estado>> Get()
        {
            return Ok(_EstadoService.ObtenerTodos());
        }
    }
}
