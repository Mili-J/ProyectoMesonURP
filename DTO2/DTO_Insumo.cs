using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Insumo
    {
        public int I_idInsumo { get; set; }
        public string I_nombreInsumo { get; set; }
        public decimal I_cantidad { get; set; }
        public decimal I_cantidadmin { get; set; }
        public decimal I_pesoTotal { get; set; }
        public int CI_idCategoria { get; set; }
        public int EI_idEstadoInsumo { get; set; }
    }
}
