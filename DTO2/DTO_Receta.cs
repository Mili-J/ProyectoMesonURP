using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Receta
    {
        public int R_idReceta { get; set; }
        public string R_nombreReceta { get; set; }
        public int R_numeroPorcion { get; set; }
        public string R_descripcion { get; set; }
        public Byte[] R_imagenReceta { get; set; }
        public int CR_idCategoriaReceta { get; set; }
       

    }
}
