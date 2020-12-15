using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using System.Data;
using DTO;
namespace CTR
{
    public class CTR_Cotizacion
    {
        DAO_Cotizacion dao_cotizacion;
        public CTR_Cotizacion()
        {
            dao_cotizacion = new DAO_Cotizacion();
        }
        public DataTable DAO_Consultar_Cotizaciones()
        {
            return dao_cotizacion.DAO_Consultar_Cotizaciones();
        }
        public void CTR_Registrar_Cotizacion(DTO_Cotizacion cot)
        {
            dao_cotizacion.DAO_Registrar_Cotizacion(cot);
        }
    }
}
