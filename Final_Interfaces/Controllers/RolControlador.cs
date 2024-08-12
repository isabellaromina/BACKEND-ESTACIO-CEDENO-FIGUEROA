using Microsoft.AspNetCore.Mvc;
using Proyecto_Final.Entidades;
using Proyecto_Final.Repositorios;

namespace Final_Interfaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RolController : ControllerBase
    {
        private readonly IRepositorioRol _repositorioRol;

        public RolController(IRepositorioRol repositorioRol)
        {
            _repositorioRol = repositorioRol;
        }

     
        [HttpGet]
        public async Task<ActionResult<List<Rol>>> GetRoles()
        {
            var roles = await _repositorioRol.ObtenerTodos();
            return Ok(roles);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _repositorioRol.ObtenerPorId(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

       
        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(Rol rol)
        {
            await _repositorioRol.Crear_Rol(rol);
            return CreatedAtAction(nameof(GetRol), new { id = rol.Id }, rol);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, Rol rol)
        {
            if (id != rol.Id)
            {
                return BadRequest();
            }

            await _repositorioRol.Modificar_Rol(rol);
            return NoContent();
        }

       }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var rol = await _repositorioRol.ObtenerPorId(id);
            if (rol == null)
            {
                return NotFound();
            }

            await _repositorioRol.Eliminar_Rol(id);
            return NoContent();
        }
    }
}
