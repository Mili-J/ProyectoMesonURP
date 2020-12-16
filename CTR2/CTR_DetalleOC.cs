using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTR
{
    public class CTR_DetalleOC
    {
        DAO_DetalleOC dao_detalleOC;
        public CTR_DetalleOC()
        {
            dao_detalleOC = new DAO_DetalleOC();
        }
        public void RegistrarDetalleOC(DTO_DetalleOC objDto)
        {
            dao_detalleOC.InsertDetalleOC(objDto);
        }
        public void UPDATE_cantidadEntregada(decimal cantidad, int idDetalleOC)
        {
            dao_detalleOC.UPDATE_cantidadEntregada(cantidad, idDetalleOC);
        }
    }
}
