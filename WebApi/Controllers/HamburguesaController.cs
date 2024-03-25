using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ProgramacionWebII_Actividad_Complementaria_CSharp;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HamburguesaController : ControllerBase
    {
        private readonly ILogger<HamburguesaController> _logger;
        private readonly List<Hamburguesa> _hamburguesas;

        public HamburguesaController(ILogger<HamburguesaController> logger)
        {
            _logger = logger;
            _hamburguesas = new List<Hamburguesa>();
        }

        [HttpGet]
        public IEnumerable<Hamburguesa> Get()
        {
            return _hamburguesas;
        }

        [HttpPost]
        public ActionResult<Hamburguesa> Post([FromBody] Hamburguesa hamburguesa)
        {
            // Agrega una nueva hamburguesa
            hamburguesa.IdHamburguesa = Guid.NewGuid();
            _hamburguesas.Add(hamburguesa);
            return CreatedAtAction(nameof(Get), new { id = hamburguesa.IdHamburguesa }, hamburguesa);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Hamburguesa hamburguesa)
        {
            // Actualiza una hamburguesa existente
            var HamburguesaExistente = _hamburguesas.FirstOrDefault(h => h.IdHamburguesa == id);
            if (HamburguesaExistente == null)
            {
                return NotFound();
            }
            HamburguesaExistente.Nombre = hamburguesa.Nombre;
            HamburguesaExistente.Precio = hamburguesa.Precio;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            // Elimina una hamburguesa existente
            var HamburguesaExistente = _hamburguesas.FirstOrDefault(h => h.IdHamburguesa == id);
            if (HamburguesaExistente == null)
            {
                return NotFound();
            }

            _hamburguesas.Remove(HamburguesaExistente);

            return Ok();
        }
    }
}
