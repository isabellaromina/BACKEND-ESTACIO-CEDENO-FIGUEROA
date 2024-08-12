using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaInicio { get; set; }
        public Genero Genero { get; set; }

  
        public int RolId { get; set; }

    }
}
