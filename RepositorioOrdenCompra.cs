using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Final.Repositorios
{
    public class RepositorioOrdenCompra : IRepositorioOrdenCompra
    {
        private readonly ApplicationDbContext context;
        public RepositorioOrdenCompra(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<OrdenCompra>> ObtenerOrden()
        {
            return await context.OrdenCompras.ToListAsync();
        }

        public async Task<OrdenCompra?> ObtenerOrdenPorId(int id)
        {
            return context.OrdenCompras.Where(orden => orden.Id == id)
                .ToList()[0];

        }

        public async Task<int> CrearOrden(OrdenCompra ordenCompra)
        {
            context.OrdenCompras.Add(ordenCompra);
            await context.SaveChangesAsync();

            return ordenCompra.Id;
        }
        public async Task<OrdenCompra> ModificarOrden(OrdenCompra compra)
        {
            //obtener el objeto de la BD
            OrdenCompra clienteMod = await context.OrdenCompras.FindAsync(compra.Id);
            //cambiar los valores del objeto consultado
            clienteMod.ClienteId = compra.ClienteId;
            clienteMod.SolicitudCompraId = compra.SolicitudCompraId;
            clienteMod.descripcion = compra.descripcion;

            //Guardar los cambios
            await context.SaveChangesAsync();
            return clienteMod;
        }

        public async Task EliminarOrden(int id)
        {
            OrdenCompra orden = await context.OrdenCompras.FindAsync(id);
            context.OrdenCompras.Remove(orden);
            await context.SaveChangesAsync();
        }
    }
}