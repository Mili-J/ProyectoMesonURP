﻿using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
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
    }
}
