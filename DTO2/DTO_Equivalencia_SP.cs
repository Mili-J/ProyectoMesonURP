using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO2
{
    public class DTO_Equivalencia_SP
    {
        public int I_idIngrediente { get; set; }
        public string I_nombreIngrediente { get; set; }
        public decimal E_cantidad { get; set; }
        public int MXFC_idMedidaFCocina { get; set; }
        public String M_nombreMedida { get; set; }
        public String FCO_nombreFormatoCocina { get; set; }
    }
}
