using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using DTO;
using System.Data;
namespace CTR
{
    public class CTR_DetalleCotizacion
    {
        DAO_DetalleCotizacion dao_detCot;
        public CTR_DetalleCotizacion()
        {
            dao_detCot = new DAO_DetalleCotizacion();
        }
        public void CTR_RegistrarDetalleCotizacion(DTO_DetalleCotizacion detCot)
        {
            dao_detCot.DAO_RegistrarDetalleCotizacion(detCot);
        }
        public DataTable CTR_ConsultarDetallesCotizacionXCotizacion(int id)
        {
            return dao_detCot.DAO_ConsultarDetallesCotizacionXCotizacion(id);
        }
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
        public int IdDetalleCotizacion(int C_idCotizacion)
        {
            return objDAO.SelectIdDetalleCotizacion(C_idCotizacion);
        }
    }
}
