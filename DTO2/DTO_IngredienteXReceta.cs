using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_IngredienteXReceta
    {
        public int IR_idIngredienteReceta { get; set; }
        public decimal IR_cantidad { get; set; }
        public string IR_formatoMedida { get; set; }
        public int R_idReceta { get; set; }
        public int I_idIngrediente { get; set; }
    }
}
