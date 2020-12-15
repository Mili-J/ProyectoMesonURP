using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Menu
    {
        public int ME_idMenu { get; set; }
        public string ME_fechaMenu { get; set; }
        public int ME_totalPorcion { get; set; }
        public int EM_idEstadoMenu { get; set; }
    }
}
