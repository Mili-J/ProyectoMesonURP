using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Equivalencia
    {
        public int E_idEquivalencia { get; set; }
        public decimal E_cantidad { get; set; }
        //public int I_idInsumo { get; set; }
        public int I_idIngrediente { get; set; }
        public int MXFC_idMedidaFCocina { get; set; }
    }
}
