using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.Repositorios
{
    public class RepositorioRol : IRepositorioRol
    {
        private readonly ApplicationDbContext context;
        public RepositorioRol(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Rol>> ObtenerTodos()
        {
            return await context.Roles.ToListAsync();

        }

        public async Task<Rol> ObtenerPorId(int id)
        {
            return await context.Roles.FindAsync(id);
        }

        public async Task Modificar_Rol(Rol rol)
        {
            context.Roles.Update(rol);
            await context.SaveChangesAsync();
        }

        public async Task Crear_Rol(Rol rol)
        {
            await context.Roles.AddAsync(rol);
            await context.SaveChangesAsync();
        }

        public async Task Eliminar_Rol(int id)
        {
            var rol = await context.Roles.FindAsync(id);
            if (rol != null)
            {
                context.Roles.Remove(rol);
                await context.SaveChangesAsync();
            }
        }
    }
}