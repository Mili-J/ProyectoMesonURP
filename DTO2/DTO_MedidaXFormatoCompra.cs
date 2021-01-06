using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_MedidaXFormatoCompra
    {
        public int MXF_idMedidaFCompra { get; set; }
        public decimal MXF_cantidadContenida { get; set; }
        public int MXF_cantidadUnidad { get; set; }
        public int FC_idFCompra { get; set; }
        public int M_idMedida { get; set; }
    }
}
