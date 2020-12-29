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
        public void CTR_ActualizarMenuXReceta(DataTable obj)
        {
            dao_menuxreceta.DAO_ActualizarMenuXReceta(obj);
        }  
        public void DAO_ActualizarUnMenuXReceta(DTO_MenuXReceta obj)
        {
            dao_menuxreceta.DAO_ActualizarUnMenuXReceta(obj);
        }
        public bool ExistenciaMenuxReceta(int R_idReceta, string Fecha)
        {
            return dao_menuxreceta.SelectExistenciaMenuxReceta(R_idReceta, Fecha);
        }
        public DataTable CTR_ConsultarRecetasXMenuYCategoria(int M_id, int Cat_id)
        {
            return dao_menuxreceta.DAO_ConsultarRecetasXMenuYCategoria(M_id, Cat_id);
        }
        public void CTR_EliminarMenusXReceta(int id)
        {
            dao_menuxreceta.DAO_EliminarMenusXReceta(id);
        }
        public void CTR_EliminarMenu(int id)
        {
            dao_menuxreceta.DAO_EliminarMenu(id);
        }
    }
}
