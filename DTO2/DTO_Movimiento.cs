using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Movimiento
    {
        public int M_Movimiento { get; set; }
        public decimal M_cantidad { get; set; }
        public DateTime M_fechaMovimiento { get; set; }
        public int MT_idTMovimiento { get; set; }
        public int I_idInsumo { get; set; }
        public int U_idUsuario { get; set; }

	}
}
