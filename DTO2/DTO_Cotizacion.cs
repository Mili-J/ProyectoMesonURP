using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Cotizacion
    {
        public int C_idCotizacion { get; set; }
        public string C_numeroCotizacion { get; set; }
        public DateTime C_fechaEmision { get; set; }
        public string C_tiempoPlazo { get; set; }
        public string C_documento { get; set; }
        public int PR_idProveedor { get; set; }
        public int EC_idEstadoCotizacion { get; set; }
        public int U_idUsuario { get; set; }
    }
}
