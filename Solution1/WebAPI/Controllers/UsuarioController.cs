using BLL;
using Clases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioBLL usuarioDLL;

        public UsuarioController()
        {
            usuarioDLL = new UsuarioBLL();
        }

        // GET: api/Usuario
        [HttpGet]
        public List<Usuario> Get()
        {
            return usuarioDLL.ObtenerTodosLosUsuarios();
        }

        // GET: api/Usuario/{id}
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = usuarioDLL.ObtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST: api/Usuario
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario usuario)
        {
            usuarioDLL.AgregarUsuario(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuario/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!usuarioDLL.EliminarUsuario(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
