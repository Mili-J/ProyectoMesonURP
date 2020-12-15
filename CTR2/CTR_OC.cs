﻿using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

using DAO;
using System.Data;

namespace CTR
{
    public class CTR_OC
    {
        DAO_OC dao_oc;
        public CTR_OC()
        {
            dao_oc = new DAO_OC();
        }
        public DataTable ListarOC(string OC_numeroOC)
        {
            return dao_oc.ListarOC(OC_numeroOC);
        }
        public DataTable BuscarOC(int idOC)
        {
            return dao_oc.BuscarOC(idOC);
        }
        public DataTable ListarOC2(int idOC)
        {
            return dao_oc.ListarOC_2(idOC);
        }
        public void UPDATE_EstadoOC(int idOC)
        {
            dao_oc.UPDATE_EstadoOC(idOC);
        }
        public void EnviarOC(DTO_OC objDTO, int idCotizacion, string html)
        {
            objDAO.EnviarCorreo(objDTO, idCotizacion, html);
        }
    }
}
