using Clases;
using BLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoBLL pedidoDLL;

        public PedidoController()
        {
            pedidoDLL = new PedidoBLL();
        }

        // GET: api/Pedido
        [HttpGet]
        public List<Pedido> Get()
        {
            return pedidoDLL.ObtenerTodosLosPedidos();
        }

        // GET: api/Pedido/{id}
        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(int id)
        {
            var pedido = pedidoDLL.ObtenerPedidoPorId(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        // POST: api/Pedido
        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] Pedido pedido)
        {
            pedidoDLL.AgregarPedido(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
        }

        // PUT: api/Pedido/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                BadRequest();
            }
            pedidoDLL.ActualizarCantidad(id, pedido.Cantidad);
        }

        // DELETE: api/Pedido/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!pedidoDLL.EliminarPedido(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}