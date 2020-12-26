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
        public DataSet ListarMedidaXFCocina(DTO_MedidaXFormatoCocina objFCocina)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Select_Medida_X_FCocina", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FCO_idFCocina", objFCocina.FCO_idFCocina));
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conexion.Close();
            return ds;
        }
        public DataTable ListarMedidaXFCocina2()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_Select_MedidaXFCocina", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
