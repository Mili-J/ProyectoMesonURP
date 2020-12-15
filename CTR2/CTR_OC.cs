using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTR
{
   public class CTR_OC
    {
        DAO_OC objDAO;
        public CTR_OC()
        {
            objDAO = new DAO_OC();
        }
        public void EnviarOC(DTO_OC objDTO,int idCotizacion,string html) {
            objDAO.EnviarCorreo(objDTO, idCotizacion, html);
        }
    }
}
