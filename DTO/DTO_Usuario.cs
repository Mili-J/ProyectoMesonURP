using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Usuario
    {
        public int U_idUsuario { get; set; }
        public string U_codigo { get; set; }
        public string U_contraseña { get; set; }
        public int TU_idTipoUsuario { get; set; }
        public int P_idPersona { get; set; }

    }
}
