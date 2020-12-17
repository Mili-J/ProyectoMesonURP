using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO2
{
    public class DTO_OC_SP
    {
        public int OC_idOC { get; set; }
        public int DOC_idDetalleOC { get; set; }
        public int OC_numeroOC { get; set; }
        public int I_idInsumo { get; set; }
        public String I_nombreInsumo { get; set; }
        public double DC_cantidadCotizacion { get; set; }
        public DateTime OC_fechaEmision { get; set; }
        public DateTime OC_fechaEntrega { get; set; }
    }
}
