using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Final.Entidades
{
    public class SolicitudCompra
    {
        public int Id { get; set; }

        public DateOnly FechaEmision { get; set; }
  
        public string descripcion { get; set; } = null!;

        public string estado { get; set; } = null!;
    }
}
