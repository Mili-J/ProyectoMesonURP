using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
namespace CTR
{
    public class CTR_EstadoCotizacion
    {
        DAO_EstadoCotizacion estCot;
        public  CTR_EstadoCotizacion()
        {
            estCot = new DAO_EstadoCotizacion();
        }
        public DTO_EstadoCotizacion CTR_ConsultarEstadoCotizacion(int id)
        {
            return estCot.DAO_ConsultarEstadoCotizacion(id);
        }
    }
}
