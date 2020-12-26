using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO2;
using DTO2;

namespace CTR2
{
    public class CTR_Formato_Cocina
    {
        DAO_Formato_Cocina objDAO;
        public CTR_Formato_Cocina()
        {
            objDAO = new DAO_Formato_Cocina();
        }

        public DTO_FormatoCocina CTR_ListarNombreFCocina(int FCO_idFCocina)
        {
            return objDAO.DAO_SelectNombreFCocina(FCO_idFCocina);
        }
    }
}
