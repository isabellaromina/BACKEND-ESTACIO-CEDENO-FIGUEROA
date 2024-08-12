using Microsoft.AspNetCore.Mvc;
using Proyecto_Final.Entidades;
using Proyecto_Final.Repositorios;

namespace Final_Interfaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SolicitudController : ControllerBase
    {
        private readonly IRepositorioSolicitudCompra _repositorioSolicitudCompra;

        public SolicitudController(IRepositorioSolicitudCompra repositorioSolicitudCompra)
        {
            _repositorioSolicitudCompra = repositorioSolicitudCompra;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioSolicitudCompra.ObtenerSolicitud();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var solicitud = await _repositorioSolicitudCompra.ObtenerSolicitudPorId(id);
                return Ok(solicitud);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(SolicitudCompra solicitud)
        {
            try
            {
                var id = await _repositorioSolicitudCompra.CrearSolicitud(solicitud);
                return Ok(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(SolicitudCompra solicitud)
        {
            try
            {
                await _repositorioSolicitudCompra.ModificarSolicitud(solicitud);
                return Ok(solicitud.Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositorioSolicitudCompra.EliminarSolicitud(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

    }
}