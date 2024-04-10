using Clases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BLL;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HamburguesaController : ControllerBase
    {
        private readonly HamburguesaBLL hamburguesaDLL;

        public HamburguesaController()
        {
            hamburguesaDLL = new HamburguesaBLL();
        }

        // GET: api/Hamburguesa
        [HttpGet]
        public List<Hamburguesa> Get()
        {
            return hamburguesaDLL.ObtenerTodasLasHamburguesas();
        }

        // GET: api/Hamburguesa/{id}
        [HttpGet("{id}")]
        public ActionResult<Hamburguesa> Get(int id)
        {
            var hamburguesa = hamburguesaDLL.ObtenerHamburguesaPorId(id);
            if (hamburguesa == null)
            {
                return NotFound();
            }
            return Ok(hamburguesa);
        }

        // POST: api/Hamburguesa
        [HttpPost]
        public ActionResult<Hamburguesa> Post([FromBody] Hamburguesa hamburguesa)
        {
            hamburguesaDLL.AgregarHamburguesa(hamburguesa);
            return CreatedAtAction(nameof(Get), new { id = hamburguesa.IdHamburguesa }, hamburguesa);
        }

        // PUT: api/Hamburguesa/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Hamburguesa hamburguesa)
        {
            if (id != hamburguesa.IdHamburguesa)
            {
                return BadRequest();
            }
            hamburguesaDLL.ActualizarHamburguesa(hamburguesa);
            return NoContent();
        }

        // DELETE: api/Hamburguesa/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!hamburguesaDLL.EliminarHamburguesa(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}