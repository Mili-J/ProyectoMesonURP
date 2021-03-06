﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using DTO;
namespace CTR
{
    public class CTR_DetalleCotizacion
    {
        DAO_DetalleCotizacion objDAO;
        public CTR_DetalleCotizacion()
        {
            objDAO = new DAO_DetalleCotizacion();
        }
        public DataTable CargarDetalleCotizacion(int C_idCotizacion)
        {
            return objDAO.SelectDetalleCotizacion(C_idCotizacion);
        }
        
        public void CTR_RegistrarDetalleCotizacion(DTO_DetalleCotizacion detCot)
        {
            objDAO.DAO_RegistrarDetalleCotizacion(detCot);
        }
        public DataTable CTR_ConsultarDetallesCotizacionXCotizacion(int id)
        {
            return objDAO.DAO_ConsultarDetallesCotizacionXCotizacion(id);
        }
        public int IdDetalleCotizacion(int C_idCotizacion, string I_nombreInsumo)
        {
            return objDAO.SelectIdDetalleCotizacion(C_idCotizacion, I_nombreInsumo);
        }
    }
}
