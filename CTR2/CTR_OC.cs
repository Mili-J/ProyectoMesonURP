using DAO;
using DTO;
using DTO2;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void RegistrarOC(DTO_OC objDto)
        {
            dao_oc.InsertOC(objDto);
        }
        public DataTable ListarOC(string OC_numeroOC)
        {
            return dao_oc.ListarOC(OC_numeroOC);
        }
        //public DataTable ListarOC(string numOC)
        //{
        //    return dao_oc.ListarOC(numOC);
        //}
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
            dao_oc.EnviarCorreo(objDTO, idCotizacion, html);
        }
        public string ListarNumeroOC()
        {
            return dao_oc.SelectNumeroOC();
        }
        public int IdOC()
        {
            return dao_oc.SelectIdOC();
        }
        public List<DTO_OC_SP> ListarOC_3(int idOC) //LISTA DE OBJETOS
        {
            return dao_oc.ListarOC_3(idOC);
        }
        public DataTable CTRPieEstadoOC()
        {
            return dao_oc.SelectPieEstadoOC();
        }

    }
}
