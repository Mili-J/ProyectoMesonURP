﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Ingrediente
    {
        public int I_idIngrediente { get; set; }
        public string I_nombreIngrediente { get; set; }
        public decimal I_pesoUnitario { get; set; }
        public decimal I_cantidad { get; set; }
        public int I_idInsumo { get; set; }
        //public int E_idEquivalencia { get; set; }

        //No borrar pls
        public string equivalencia { get; set; }
        public string I_nombreInsumo { get; set; }
    }
}
