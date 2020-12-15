using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Proveedor
    {
        public int PR_idProveedor { get; set; }
        public string PR_razonSocial { get; set; }
        public string PR_numeroDocumento { get; set; }
        public string PR_direccion { get; set; }
        public string PR_nombreContacto { get; set; }
        public string PR_telefonoContacto { get; set; }
        public string PR_correoContacto { get; set; }
        public int EP_idEstadoProveedor { get; set; }
    }
}
