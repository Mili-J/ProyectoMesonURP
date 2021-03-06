﻿using System;
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
        public DataTable CTRSelectBarChartInsumoComprar(string OC_fechaEntrega)
        {
            return dao_insumo.SelectBarChartInsumoComprar(OC_fechaEntrega);
        }
        public List<DTO_Insumo> CTR_ConsultarInsumoXCategoria(int CI_idCategoriaInsumo)
        {
            return dao_insumo.DAO_ConsultarInsumoXCategoria(CI_idCategoriaInsumo);
        }
        public Boolean ValInsumo_GI(int idInsumo)
        {
            return dao_insumo.ValEditarInsumo(idInsumo);
        }
        public void InsertInsumo(object[] NuevoInsumo)
        {
            dao_insumo.InsertInsumo_GI(NuevoInsumo);
        }
        public void EditarInsumo_GI(object[] NuevoInsumo)
        {
            dao_insumo.EditarInsumo_GI(NuevoInsumo);
        }
        public DataTable ConsultarInsumo_GI(int idInsumo)
        {
            return dao_insumo.ConsultarInsumo_GI(idInsumo);
        }
        public bool InsumoExAgr_GI(string nomInsumo)
        {
            return dao_insumo.InsumoExistenciaAgr_GI(nomInsumo);
        }
        public bool InsumoExEd_GI(string nomInsumo, int idInsumo)
        {
            return dao_insumo.InsumoExistenciaEd_GI(nomInsumo, idInsumo);
        }
    }
}
