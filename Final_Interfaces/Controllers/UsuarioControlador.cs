using Proyecto_Final.Entidades;
using Proyecto_Final.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Final_Interfaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public UsuarioController(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

    // GET: api/usuario
    [HttpGet]
    public async Task<ActionResult<List<Usuario>>> GetUsuarios()
    {
        var usuarios = await _repositorioUsuario.ObtenerTodos();
        return Ok(usuarios);
    }

    // GET: api/usuario/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuariosId(int id)
    {
        var usuario = await _repositorioUsuario.ObtenerPorId(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }

    // POST: api/usuario
    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        await _repositorioUsuario.Crear_Usuario(usuario);
        return CreatedAtAction(nameof(GetUsuariosId), new { id = usuario.Id }, usuario);
    }

    // PUT: api/usuario/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
    {
        if (id != usuario.Id)
        {
            return BadRequest();
        }

        await _repositorioUsuario.Modificar_Usuario(usuario);
        return NoContent();
    }

    // DELETE: api/usuario/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuario = await _repositorioUsuario.ObtenerPorId(id);
        if (usuario == null)
        {
            return NotFound();
        }

        await _repositorioUsuario.Eliminar_Usuario(id);
        return NoContent();
    }

    }
}
