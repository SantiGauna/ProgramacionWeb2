using Clases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private static List<Pedido> _pedidos = new List<Pedido>
        {
            new Pedido { Id = 1, IdUsuario = 101 },
            new Pedido { Id = 2, IdUsuario = 102 },
            new Pedido { Id = 3, IdUsuario = 103 }
        };

        // GET: Pedido
        [HttpGet]
        public List<Pedido> Get()
        {
            return _pedidos;
        }

        // GET: Pedido/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pedido = _pedidos.Find(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        // POST: Pedido
        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }

            _pedidos.Add(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
        }

        // PUT: Pedido/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pedido pedido)
        {
            var index = _pedidos.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                return NotFound();
            }

            _pedidos[index] = pedido;
            return NoContent();
        }

        // DELETE: Pedido/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = _pedidos.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                return NotFound();
            }

            _pedidos.RemoveAt(index);
            return NoContent();
        }
    }
}
