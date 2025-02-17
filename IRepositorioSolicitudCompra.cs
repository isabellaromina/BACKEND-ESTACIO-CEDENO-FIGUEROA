﻿using Proyecto_Final.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Repositorios
{
    public interface IRepositorioSolicitudCompra
    {
        Task<List<SolicitudCompra>> ObtenerSolicitud();
        Task<SolicitudCompra?> ObtenerSolicitudPorId(int id);
        Task<int> CrearSolicitud(SolicitudCompra solicitudCompra);
        Task<SolicitudCompra> ModificarSolicitud(SolicitudCompra solicitudCompra);
        Task EliminarSolicitud(int id);
    }
}
