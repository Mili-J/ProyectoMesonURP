﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_MenuXReceta
    {
        public int MXR_idMenuReceta { get; set; }
        public int R_idReceta { get; set; }
        public int ME_idMenu { get; set; }
        public int MXR_numeroPorcion { get; set; }

    }
}
