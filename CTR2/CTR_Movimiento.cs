using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTR
{
    public class CTR_Movimiento
    {
        DAO_Movimiento dao_movimiento;
        public CTR_Movimiento()
        {
            dao_movimiento = new DAO_Movimiento();
        }
        public void InsertMovGO(DTO_Movimiento objDto)
        {
            dao_movimiento.InsertMovimientoGO(objDto);
        }
        public DataTable ListarMovimiento(string FechaInicial, string FechaFinal)
        {
            return dao_movimiento.SelectMovimiento(FechaInicial, FechaFinal);
        }
    }
}
