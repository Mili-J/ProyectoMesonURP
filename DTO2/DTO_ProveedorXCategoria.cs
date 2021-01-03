using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO2
{
    public class DTO_ProveedorXCategoria
    {
        public int PXC_idProveedorC { get; set; }
        public int PR_idProveedor { get; set; }
        public int CI_idCategoriaInsumo { get; set; }
    }
}
