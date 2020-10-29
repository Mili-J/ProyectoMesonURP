using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Receta
    {
        public string @R_nombreReceta { get; set; }
        public int @R_numeroPorcion { get; set; }
        public byte @R_imagenReceta { get; set; }
        public int @CR_idCategoriaReceta { get; set; }
        
    }
}
