using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly ApplicationDbContext context;
        public RepositorioUsuario(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Usuario>> ObtenerTodos()
        {
            return await context.Usuarios.ToListAsync();

        }

        public async Task<Usuario> ObtenerPorId(int id)
        {
            return await context.Usuarios.FindAsync(id);
        }


        public async Task Modificar_Usuario(Usuario usuario)
        {
            context.Usuarios.Update(usuario);
            await context.SaveChangesAsync();
        }

        public async Task Crear_Usuario(Usuario usuario)
        {
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
        }

        public async Task Eliminar_Usuario(int id)
        {
            var usuario = await context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                await context.SaveChangesAsync();
            }
        }
    }
}