﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_DetalleCotizacion
    {
        public int DC_idDetalleCotizacion { get; set; }
        public decimal DC_cantidadCotizacion { get; set; }
        public int C_idCotizacion { get; set; }
        public int I_idInsumo { get; set; }
        public string I_nombreInsumo { get; set; }
        public string FC_nombreFormatoCompra { get; set; }
        public string MXF_cantidadContenida { get; set; }
        public string M_nombreMedida { get; set; }

    }
}
