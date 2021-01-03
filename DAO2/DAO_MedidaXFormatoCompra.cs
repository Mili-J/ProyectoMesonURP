using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_MedidaXFormatoCompra
    {
        SqlConnection conexion;
        public DAO_MedidaXFormatoCompra()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public DTO_MedidaXFormatoCompra DAO_ConsultarMedidaXFormatoCompra(int id)
        {
            DTO_MedidaXFormatoCompra dto_medidaxformatoCompra = new DTO_MedidaXFormatoCompra();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarMedidaXFormatoCompra", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@MXF_idMedidaFCompra", id);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                dto_medidaxformatoCompra.MXF_idMedidaFCompra = Convert.ToInt32(reader[0]);
                dto_medidaxformatoCompra.MXF_cantidadContenida = Convert.ToDecimal(reader[1]);
                dto_medidaxformatoCompra.MXF_cantidadUnidad = Convert.ToInt32(reader[2]);
                dto_medidaxformatoCompra.FC_idFCompra = Convert.ToInt32(reader[3]);
                dto_medidaxformatoCompra.M_idMedida = Convert.ToInt32(reader[4]);
            }
            conexion.Close();
            return dto_medidaxformatoCompra;
        }
    }
}
