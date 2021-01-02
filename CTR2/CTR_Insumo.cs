using System;
using System.Collections.Generic;
using System.Text;

using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CTR_Insumo
    {
        DAO_Insumo dao_insumo;
        public CTR_Insumo()
        {
            dao_insumo = new DAO_Insumo();
        }
        public DataTable ListarInsumo()
        {
            return dao_insumo.ListarInsumo();
        }
        public DataTable ConsultarInsumo(string nombreInsumo)
        {
            return dao_insumo.ConsultarInsumo(nombreInsumo);
        }
        public DataTable ListarInsumo2()
        {
            return dao_insumo.ListarInsumo2();
        }
        public DataTable BuscarInsumo(int idInsumo)
        {
            return dao_insumo.BuscarInsumo(idInsumo);
        }
        public DataTable BuscarInsumoF(string nombreInsumo)
        {
            return dao_insumo.BuscarInsumoF(nombreInsumo);
        }
        public DataTable CTR_CONSULTAR_EQUIVALENCIA_X_INSUMO(DTO_Insumo dto_insumo)
        {
            return dao_insumo.DAO_Consultar_Equivalencia_x_Insumo(dto_insumo);
        }
        public DTO_Medida CTR_Consultar_Medida_x_Insumo(DTO_Insumo objInsumo)
        {
            return dao_insumo.DAO_Consultar_Medida_x_Insumo(objInsumo);
        }
        public DataTable BuscarInsumoP(int idInsumo)
        {
            return dao_insumo.BuscarInsumoP(idInsumo);
        }

        public void ActualizarCantidadI(DTO_Insumo objInsumo)
        {
            dao_insumo.DAO_Actualizar_Cantidad_Insumo(objInsumo);
        }

        public void UPDATE_cantidadInsumoOC(decimal cantidad, int idInsumo)
        {
            dao_insumo.UPDATE_cantidadInsumo(cantidad, idInsumo);
        }
        public DataTable CTRSelectBarChartInsumoD()
        {
            return dao_insumo.SelectBarChartInsumoD();
        }
        public DataTable CTRSelectBarChartInsumoComprar()
        {
            return dao_insumo.SelectBarChartInsumoComprar();
        }
        public void InsertInsumo(object[]parir)
        {
            dao_insumo.InsertInsumo(parir);
        }
    }
}
