using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.Repositorios
{
    public interface IRepositorioRol
    {
        Task<List<Rol>> ObtenerTodos();
        Task<Rol> ObtenerPorId(int id);
        Task Crear_Rol(Rol rol);
        Task Eliminar_Rol(int id);
        Task Modificar_Rol(Rol rol);
    }
}
