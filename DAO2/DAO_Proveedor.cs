using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DTO2;
namespace DAO
{
    public class DAO_Proveedor
    {
        SqlConnection conexion;
        DTO_Proveedor app;

        public DAO_Proveedor()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public DataTable ListarProveedores(string @razonSocial)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_ConsultarProveedores", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@razonSocial", razonSocial);
                DataSet dSet = new DataSet();
                cmd.Fill(dSet);
                return dSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CambiarEstadoProveedor(int PR_idProveedor, int EP_idEstadoProveedor)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_ESTADO_PROVEEDOR", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@PR_idProveedor", PR_idProveedor));
            unComando.Parameters.Add(new SqlParameter("@EP_idEstadoProveedor", EP_idEstadoProveedor));
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public int RegistrarProveedor(DTO_Proveedor obj)
        {
            int resultado = 0;
            try
            {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_INSERT_PROVEEDOR", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@PR_razonSocial", obj.PR_razonSocial));
                unComando.Parameters.Add(new SqlParameter("@PR_numeroDocumento", obj.PR_numeroDocumento));
                unComando.Parameters.Add(new SqlParameter("@PR_direccion", obj.PR_direccion));
                unComando.Parameters.Add(new SqlParameter("@PR_nombreContacto", obj.PR_nombreContacto));
                unComando.Parameters.Add(new SqlParameter("@PR_telefonoContacto", obj.PR_telefonoContacto));
                unComando.Parameters.Add(new SqlParameter("@PR_correoContacto", obj.PR_correoContacto));
                unComando.Parameters.Add(new SqlParameter("@EP_idEstadoProveedor", 1));
                unComando.Parameters.Add("@ProveedorID", SqlDbType.Int).Direction = ParameterDirection.Output;
                unComando.ExecuteNonQuery();
                int id = Convert.ToInt32(unComando.Parameters["@ProveedorID"].Value.ToString());
                conexion.Close();
                resultado = id;
            }
            catch (Exception e)
            {
                resultado = 0;
            }
            return resultado;
        }

        public void RegistrarProveedorxCategoria(int PR_idProveedor, int CI_idCategoriaInsumo)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_INSERT_PROVEEDORXCATEGORIA", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@PR_idProveedor", PR_idProveedor));
            unComando.Parameters.Add(new SqlParameter("@CI_idCategoriaInsumo", CI_idCategoriaInsumo));
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public List<int> TraerCategorias(int PR_idProveedor)
        {
            List<int> lista = new List<int>();
            DTO_ProveedorXCategoria app = new DTO_ProveedorXCategoria();
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_ConsultarCategoriasProveedor", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@PR_idProveedor", PR_idProveedor);
                DataSet ds = new DataSet();
                cmd.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lista.Add(app.CI_idCategoriaInsumo = Convert.ToInt32(dr["CI_idCategoriaInsumo"]));
                }
                return lista;
            }


            catch (Exception ex)
            {
                throw ex;
            }



        }

        public DTO_Proveedor traerProveedor(int PR_idProveedor)
        {

            DTO_Proveedor app = new DTO_Proveedor();
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_ConsultarProveedor", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@PR_idProveedor", PR_idProveedor);
                DataSet ds = new DataSet();
                cmd.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    app = new DTO_Proveedor
                    {
                        PR_idProveedor = Convert.ToInt32(PR_idProveedor),
                        PR_razonSocial = Convert.ToString(dr["PR_razonSocial"]),
                        PR_numeroDocumento = Convert.ToString(dr["PR_numeroDocumento"]),
                        PR_direccion = Convert.ToString(dr["PR_direccion"]),
                        PR_nombreContacto = Convert.ToString(dr["PR_nombreContacto"]),
                        PR_telefonoContacto = Convert.ToString(dr["PR_telefonoContacto"]),
                        PR_correoContacto = Convert.ToString(dr["PR_correoContacto"]),
                        EP_idEstadoProveedor = Convert.ToInt32(dr["EP_idEstadoProveedor"])
                    };
                }
                return app;
            }


            catch (Exception ex)
            {
                throw ex;
            }



        }


        public DTO_Proveedor actualizarProveedor(DTO_Proveedor obj)
        {

            DTO_Proveedor app = new DTO_Proveedor();
            try
            {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_UPDATE_Proveedor", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@PR_idProveedor", obj.PR_idProveedor));
                unComando.Parameters.Add(new SqlParameter("@PR_razonSocial", obj.PR_razonSocial));
                unComando.Parameters.Add(new SqlParameter("@PR_numeroDocumento", obj.PR_numeroDocumento));
                unComando.Parameters.Add(new SqlParameter("@PR_direccion", obj.PR_direccion));
                unComando.Parameters.Add(new SqlParameter("@PR_nombreContacto", obj.PR_nombreContacto));
                unComando.Parameters.Add(new SqlParameter("@PR_telefonoContacto", obj.PR_telefonoContacto));
                unComando.Parameters.Add(new SqlParameter("@PR_correoContacto", obj.PR_correoContacto));
                unComando.ExecuteNonQuery();
                conexion.Close();
                return app;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarProveedorxCategoria(int PR_idProveedor, int CI_idCategoriaInsumo)
        {
            try
            {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_DELETE_PROVEEDORXCATEGORIA", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@PR_idProveedor", PR_idProveedor));
                unComando.Parameters.Add(new SqlParameter("@CI_idCategoriaInsumo", CI_idCategoriaInsumo));
                unComando.ExecuteNonQuery();
                conexion.Close();

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DAO_ConsultarProveedores()
        {
            DataTable dt = new DataTable();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Proveedor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DTO_Proveedor DAO_ConsultarProveedor(int id)
        {
            conexion.Open();
            DTO_Proveedor pro = new DTO_Proveedor();
            SqlCommand comando = new SqlCommand("SP_ConsultarProveedor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PR_idProveedor", id);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                pro.PR_idProveedor = Convert.ToInt32(reader[0]);
                pro.PR_razonSocial = Convert.ToString(reader[1]);
                pro.PR_numeroDocumento = Convert.ToString(reader[2]);
                pro.PR_direccion = Convert.ToString(reader[3]);
                pro.PR_nombreContacto = Convert.ToString(reader[4]);
                pro.PR_telefonoContacto = Convert.ToString(reader[5]);
                pro.PR_correoContacto = Convert.ToString(reader[6]);
                pro.EP_idEstadoProveedor = Convert.ToInt32(reader[7]);
            }
            conexion.Close();
            return pro;
        }
    }
}
