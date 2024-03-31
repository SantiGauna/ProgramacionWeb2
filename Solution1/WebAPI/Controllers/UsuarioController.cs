using Clases; 
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> _usuarios = new List<Usuario>
        {
            new Usuario { IdUsuario = 1, Nombre = "Usuario1" },
            new Usuario { IdUsuario = 2, Nombre = "Usuario2" },
            new Usuario { IdUsuario = 3, Nombre = "Usuario3" }
        };

        // GET: Usuario
        [HttpGet]
        public List<Usuario> Get()
        {
            return _usuarios;
        }

        // GET: Usuario/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _usuarios.Find(u => u.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST: Usuario
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            _usuarios.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.IdUsuario }, usuario);
        }

        // PUT: Usuario/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            var index = _usuarios.FindIndex(u => u.IdUsuario == id);
            if (index == -1)
            {
                return NotFound();
            }

            _usuarios[index] = usuario;
            return NoContent();
        }

        // DELETE: Usuario/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = _usuarios.FindIndex(u => u.IdUsuario == id);
            if (index == -1)
            {
                return NotFound();
            }

            _usuarios.RemoveAt(index);
            return NoContent();
        }
    }
}
