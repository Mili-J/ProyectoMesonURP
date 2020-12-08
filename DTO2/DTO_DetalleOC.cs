using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_DetalleOC
    {
		public int DOC_idDetalleOC { get; set; }
		public decimal DOC_precioUnitario { get; set; }
		public decimal DOC_totalPrecio { get; set; }
		public decimal DOC_cantidadEntregada { get; set; }
		public int OC_idOC { get; set; }
		public int DC_idDetalleCotizacion { get; set; }

	}
}
