using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_Medida
    {
        DAO_Medida objDAO;
        public CTR_Medida()
        {
            objDAO = new DAO_Medida();
        }

        public DTO_Medida CTR_ListarNombreMedida(int M_idMedida)
        {
            return objDAO.DAO_SelectNombreMedida(M_idMedida);
        }
        public DataSet SelectMedida_GI()
        {
            return objDAO.SelectMedida_GI();
        }
        public DTO_Medida CTR_ConsultarMedida(int id)
        {
            return objDAO.DAO_ConsultarMedida(id);
        }
    }
}
