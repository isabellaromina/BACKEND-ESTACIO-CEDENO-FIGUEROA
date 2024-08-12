using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Entidades

{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nombre { get; set; } 

        public string apellido { get; set; } 

        public string telefono { get; set; } 

        public string correo { get; set; } 

        public string direccion { get; set; } 

        public string genero { get; set; }
    }
}