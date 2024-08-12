using Proyecto_Final.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Repositorios
{
    public class RepositorioSolicitudCompra : IRepositorioSolicitudCompra
    {
        private readonly ApplicationDbContext context;
        public RepositorioSolicitudCompra(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<SolicitudCompra>> ObtenerSolicitud()
        {
            return await context.SolicitudCompras.ToListAsync();
        }

        public async Task<SolicitudCompra?> ObtenerSolicitudPorId(int id)
        {
            return context.SolicitudCompras.Where(solicitud => solicitud.Id == id)
                .ToList()[0];

        }

        public async Task<int> CrearSolicitud(SolicitudCompra solicitud)
        {
            context.SolicitudCompras.Add(solicitud);
            await context.SaveChangesAsync();

            return solicitud.Id;
        }
        public async Task<SolicitudCompra> ModificarSolicitud(SolicitudCompra solicitud)
        {
            
            SolicitudCompra clienteMod = await context.SolicitudCompras.FindAsync(solicitud.Id);
            clienteMod.FechaEmision = solicitud.FechaEmision;
            clienteMod.descripcion = solicitud.descripcion;
            clienteMod.estado = solicitud.estado;

            await context.SaveChangesAsync();
            return clienteMod;
        }

        public async Task EliminarSolicitud(int id)
        {
            SolicitudCompra solicitud = await context.SolicitudCompras.FindAsync(id);
            context.SolicitudCompras.Remove(solicitud);
            await context.SaveChangesAsync();
        }
    }
}
