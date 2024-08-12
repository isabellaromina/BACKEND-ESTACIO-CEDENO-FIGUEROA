using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly ApplicationDbContext context;
        public RepositorioCliente(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Cliente>> ObtenerClientes()
        {
            return await context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> ObtenerClientePorId(int id)
        {
            return context.Clientes.Where(cliente => cliente.Id == id)
                .ToList()[0];

        }

        public async Task<int> CrearCliente(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            return cliente.Id;
        }
        public async Task<int> ModificarCliente(Cliente cliente)
        {
            // Buscar el cliente por Id en la base de datos
            Cliente? clienteMod = await context.Clientes.FindAsync(cliente.Id);

            // Verificar si el cliente fue encontrado
            if (clienteMod == null)
            {
                // Manejar el caso cuando no se encuentra el cliente
                throw new InvalidOperationException($"No se encontró un cliente con el ID {cliente.Id}");
            }

            // Actualizar las propiedades del cliente
            clienteMod.Nombre = cliente.Nombre;
            clienteMod.apellido = cliente.apellido;
            clienteMod.telefono = cliente.telefono;
            clienteMod.correo = cliente.correo;
            clienteMod.direccion = cliente.direccion;
            clienteMod.genero = cliente.genero;

            // Guardar los cambios en la base de datos
            await context.SaveChangesAsync();

            // Retornar el Id del cliente modificado
            return clienteMod.Id;
        }

        public async Task EliminarCliente(int id)
        {
            Cliente cliente = await context.Clientes.FindAsync(id);
            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();
        }
    }
}
