using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.Repositorios
{
    public interface IRepositorioCliente
    {
        Task<List<Cliente>> ObtenerClientes();
        Task<Cliente?> ObtenerClientePorId(int id);
        Task<int> CrearCliente(Cliente cliente);
        Task<int> ModificarCliente(Cliente cliente);
        Task EliminarCliente(int id);
    }
}
