using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
    }
}
