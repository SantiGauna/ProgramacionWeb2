using Clases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HamburguesaController : ControllerBase
    {
        private static List<Hamburguesa> _hamburguesas = new List<Hamburguesa>
        {
            new Hamburguesa { IdHamburguesa = 1, Nombre = "Clásica", Precio = 5.99 },
            new Hamburguesa { IdHamburguesa = 2, Nombre = "Doble carne", Precio = 8.99 },
            new Hamburguesa { IdHamburguesa = 3, Nombre = "Vegetariana", Precio = 6.49 }
        };

        // GET: Hamburguesa
        [HttpGet]
        public List<Hamburguesa> Get()
        {
            return _hamburguesas;
        }

        // GET: Hamburguesa/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hamburguesa = _hamburguesas.Find(h => h.IdHamburguesa == id);
            if (hamburguesa == null)
            {
                return NotFound();
            }
            return Ok(hamburguesa);
        }

        // POST: Hamburguesa
        [HttpPost]
        public IActionResult Post([FromBody] Hamburguesa hamburguesa)
        {
            if (hamburguesa == null)
            {
                return BadRequest();
            }

            _hamburguesas.Add(hamburguesa);
            return CreatedAtAction(nameof(Get), new { id = hamburguesa.IdHamburguesa }, hamburguesa);
        }

        // PUT: Hamburguesa/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Hamburguesa hamburguesa)
        {
            var index = _hamburguesas.FindIndex(h => h.IdHamburguesa == id);
            if (index == -1)
            {
                return NotFound();
            }

            _hamburguesas[index] = hamburguesa;
            return NoContent();
        }

        // DELETE: Hamburguesa/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = _hamburguesas.FindIndex(h => h.IdHamburguesa == id);
            if (index == -1)
            {
                return NotFound();
            }

            _hamburguesas.RemoveAt(index);
            return NoContent();
        }
    }
}
