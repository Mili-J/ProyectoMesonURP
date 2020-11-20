using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_MedidaXFormatoCocina
    {
        SqlConnection conexion;
        DTO_MedidaXFormatoCocina dto_medidaxfc;
        int MXFC_idMedidaFCocina = 0;

        public DAO_MedidaXFormatoCocina()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_medidaxfc = new DTO_MedidaXFormatoCocina();
        }
        public int DAO_Consultar_Medida_x_FCocina(DTO_MedidaXFormatoCocina objMedidaFC)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_SELECT_MEDIDA_X_FORMATOC", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@M_idMedida", objMedidaFC.M_idMedida));
            cmd.Parameters.Add(new SqlParameter("@FCO_idFCocina", objMedidaFC.FCO_idFCocina));
            SqlDataReader reader = cmd.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                MXFC_idMedidaFCocina = (int)reader[0];
            }
            conexion.Close();
            return MXFC_idMedidaFCocina;

        }

    }
}
