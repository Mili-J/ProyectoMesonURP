using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CTR_MenuXReceta
    {
        DAO_MenuXReceta dao_menuxreceta;
        public CTR_MenuXReceta()
        {
            dao_menuxreceta = new DAO_MenuXReceta();
        }
        public void CTR_RegistrarMenuXReceta(DTO_MenuXReceta obj)
        {
            dao_menuxreceta.DAO_RegistrarMenuXReceta(obj);
        }
        public DataTable CTR_ConsultarRecetasXMenu(int i)
        {
            return dao_menuxreceta.DAO_ConsultarRecetasXMenu(i);
        }
    }
}
