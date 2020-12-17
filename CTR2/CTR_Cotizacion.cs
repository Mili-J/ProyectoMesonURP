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
        public DataTable CTR_Consultar_Cotizaciones()
        {
            return dao_cotizacion.DAO_Consultar_Cotizaciones();
        }
        public void CTR_Registrar_Cotizacion(DTO_Cotizacion cot)
        {
            dao_cotizacion.DAO_Registrar_Cotizacion(cot);
        }
        public int CTR_IdCotizacionMayor()
        {
            return dao_cotizacion.DAO_IdCotizacionMayor();
        }
        public DTO_Cotizacion CTR_ConsultarCotizacion(int id)
        {
            return dao_cotizacion.DAO_ConsultarCotizacion(id);
        }
        public void CTR_Actualizar_Cotizacion(DTO_Cotizacion cot)
        {
            dao_cotizacion.DAO_Actualizar_Cotizacion(cot);
        }
        public void EnviarCorreo(DTO_Cotizacion dto_cot, string msj)
        {
            dao_cotizacion.EnviarCorreo(dto_cot,msj);
        }
    }
}
