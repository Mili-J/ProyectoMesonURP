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
        public byte[] R_imagenReceta { get; set; }
        public string R_subcategoria { get; set; }
        public int EP_idEstadoReceta { get; set; }
        public int CP_idCategoriaReceta { get; set; }
        public int CR_idCategoriaReceta { get; set; }
        

    }
}
