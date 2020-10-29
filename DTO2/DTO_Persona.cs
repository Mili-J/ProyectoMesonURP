using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Persona
    {
        public int P_idPersona { get; set; }
        public string P_nombres { get; set; }
        public string P_aPaterno { get; set; }
        public string P_aMaterno { get; set; }
        public string P_celular { get; set; }
        public string P_correo { get; set; }
        public string P_tipoDoc { get; set; }
        public string P_numeroDoc { get; set; }
        public byte[] P_imagen { get; set; }
    }
}
