using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_OC
    {
        public int OC_idOC { get; set; }
        public int OC_numeroOc{ get; set; }
        public DateTime OC_fechaEmision { get; set; }
        public DateTime OC_fechaEntrega { get; set; }
        public string OC_tipoPago { get; set; }
        public decimal OC_totalCompra { get; set; }
        public int EOC_idEstadoOC { get; set; }
        public int U_idUsuario { get; set; }
    }
}
