using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_CategoriaInsumo
    {
        SqlConnection conexion;

        public DAO_CategoriaInsumo()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public List<DTO_CategoriaInsumo> ListarCategoria()
        {
            List<DTO_CategoriaInsumo> app = new List<DTO_CategoriaInsumo>();
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Listar_Categoria", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    app.Add(new DTO_CategoriaInsumo
                    {
                        CI_idCategoriaInsumo = Convert.ToInt32(dr["CI_idCategoriaInsumo"]),
                        CI_nombreCategoria = Convert.ToString(dr["CI_nombreCategoria"])
                    });

                }
                return app;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DAO_ConsultarCategoriasInsumo()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarCategoriasInsumo", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataTable dtCat = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dtCat);
            conexion.Close();
            return dtCat;
        }

        public DataSet DAO_SelectCategoriaI()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Listar_Categoria", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);
            conexion.Close();
            return ds;
        }
        public DataSet DAO_SelectInsumoXCategoria(DTO_CategoriaInsumo objCategoriaI)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Listar_Insumo_x_Categoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCategoria", objCategoriaI.CI_idCategoriaInsumo));
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conexion.Close();
            return ds;
        }
        //EJEMLO DE COMO DEBERIA USARSE LAS CONSULTAS CON LISTA AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        public List<DTO_CategoriaInsumo> DAO_ConsultarCategoriasInsumo2()
        {
            List<DTO_CategoriaInsumo> list = new List<DTO_CategoriaInsumo>();
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SP_ConsultarCategoriasInsumo", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    DTO_CategoriaInsumo dto = new DTO_CategoriaInsumo()
                    {
                        CI_idCategoriaInsumo = int.Parse(reader[0].ToString()),
                        CI_nombreCategoria = reader[1].ToString()
                    };
                    list.Add(dto);
                }
            }
            catch (Exception)
            {
                throw;
            }
            conexion.Close();
            return list;
        }
     
        //para usar ahora
        public void DAO_InsertCategoriaInsumo(DTO_CategoriaInsumo cat)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_INSERT_CATEGORIA_INSUMO", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CI_nombreCategoria", cat.CI_nombreCategoria);   
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void DAO_ActualizarCategoriaInsumo(DTO_CategoriaInsumo cat)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_UPDATE_CATEGORIA_INSUMO", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CI_idCategoriaInsumo", cat.CI_idCategoriaInsumo);
            comando.Parameters.AddWithValue("@CI_nombreCategoria", cat.CI_nombreCategoria);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
