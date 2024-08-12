using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.Repositorios
{
    public interface IRepositorioUsuario
    {
        Task<List<Usuario>> ObtenerTodos();
        Task<Usuario> ObtenerPorId(int id);
        Task Crear_Usuario(Usuario usuario);
        Task Eliminar_Usuario(int id);
        Task Modificar_Usuario(Usuario usuario);

    }
}
