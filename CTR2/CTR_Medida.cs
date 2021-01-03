using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
namespace CTR
{
    public class CTR_Medida
    {
        DAO_Medida dao_medida;
        public CTR_Medida()
        {
            dao_medida = new DAO_Medida();
        }
        public DTO_Medida CTR_ConsultarMedida(int id)
        {
            return dao_medida.DAO_ConsultarMedida(id);
        }
    }
}
