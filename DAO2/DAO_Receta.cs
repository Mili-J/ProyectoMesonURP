using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using DTO;

namespace DAO
{
    public class DAO_Receta
    {
        SqlConnection conexion;
        DAO_IngredienteXReceta dao_ingredientexreceta;
        DTO_Receta dto_receta;
        DAO_Ingrediente dao_ingrediente;
        public DAO_Receta()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dao_ingredientexreceta = new DAO_IngredienteXReceta();
            dto_receta = new DTO_Receta();
            dao_ingrediente = new DAO_Ingrediente();
        }
        public void InsertReceta(DTO_Receta objDTO)
        {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_INSERT_RECETA", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@R_nombreReceta", objDTO.R_nombreReceta));
                unComando.Parameters.Add(new SqlParameter("@R_numeroPorcion", objDTO.R_numeroPorcion));
                unComando.Parameters.Add(new SqlParameter("@R_descripcion", objDTO.R_descripcion));
                unComando.Parameters.Add(new SqlParameter("@R_imagenReceta", objDTO.R_imagenReceta));
                unComando.Parameters.Add(new SqlParameter("@R_subcategoria", objDTO.R_subcategoria));
                unComando.Parameters.Add(new SqlParameter("@EP_idEstadoReceta", objDTO.EP_idEstadoReceta));
                unComando.Parameters.Add(new SqlParameter("@CP_idCategoriaReceta", objDTO.CR_idCategoriaReceta));
            
            
                unComando.ExecuteNonQuery();
                conexion.Close();
        }
        public DataTable SelectRecetaxNombre(string @nombreReceta)
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_SELECT_RECETA_X_NOMBRE", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@nombreReceta", @nombreReceta);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet.Tables[0];
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public DataTable DAO_Consultar_Recetas()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarRecetas", conexion);
            comando.CommandType = CommandType.StoredProcedure;           
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DataTable DAO_Consultar_Recetas_X_Categoria(int categoria)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarRecetasXCategoria", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CR_idCategoriaReceta", categoria);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public  DataTable DAO_Consultar_Recetas_X_Categoria_Seleccionada(int caso)
        {
            switch (caso)
            {
                case 1://entradas y sopas
                    DataTable dtEntrada = DAO_Consultar_Recetas_X_Categoria(1);
                    dtEntrada.Merge(DAO_Consultar_Recetas_X_Categoria(3));
                    return dtEntrada;

                case 2://Segundos
                    return DAO_Consultar_Recetas_X_Categoria(2);
                default:
                    return new DataTable();//nada :C
            }
        }


        public DataTable DAO_Consultar_Recetas_Disponibles(int racion, int caso)
        {
            //TODO
            //<>
            int i = 0;
            DataTable dtRecetas = DAO_Consultar_Recetas_X_Categoria_Seleccionada(caso), dtIngredientesxReceta, dtDisponibles = new DataTable();
            if (dtDisponibles.Rows.Count == 0)
            {
                dtDisponibles.Columns.Add("R_idReceta");
                dtDisponibles.Columns.Add("R_nombreReceta");
                dtDisponibles.Columns.Add("R_numeroPorcion");
                dtDisponibles.Columns.Add("R_descripcion");
            }
            DataRow dr;
            DTO_IngredienteXReceta dto_ingredientexreceta;
            DTO_Ingrediente dto_ingrediente;
            object[] recetas, ingredientesxrecetas;
            bool valor;
            List<DTO_Receta> recetasDisponibles = new List<DTO_Receta>();
            List<DTO_Receta> prueba = new List<DTO_Receta>();


            while (i < dtRecetas.Rows.Count)
            {
                valor = true;
                dto_receta = new DTO_Receta();
                recetas = dtRecetas.Rows[i].ItemArray;
                dto_receta = DAO_Consultar_Receta(Convert.ToInt32(recetas[0]));
                dtIngredientesxReceta = dao_ingredientexreceta.DAO_Consultar_Insumo_x_Receta(dto_receta);
                int j = 0;
                while ((j < dtIngredientesxReceta.Rows.Count || dtIngredientesxReceta.Rows.Count == 0) && valor == true)
                {
                    if (j < dtIngredientesxReceta.Rows.Count)//Quitar este if
                    {
                        ingredientesxrecetas = dtIngredientesxReceta.Rows[j].ItemArray;
                        dto_ingrediente = dao_ingrediente.DAO_Consultar_IngredienteXID(Convert.ToInt32(ingredientesxrecetas[4]));
                        dto_ingredientexreceta = dao_ingredientexreceta.DAO_Consultar_IngredienteXReceta(Convert.ToInt32(ingredientesxrecetas[3]), Convert.ToInt32(ingredientesxrecetas[4]));
                        if (dto_ingredientexreceta.IR_cantidad * racion <= dto_ingrediente.I_cantidad)
                        {
                            valor = true;
                            if (j == dtIngredientesxReceta.Rows.Count - 1)
                            {

                                dr = dtDisponibles.NewRow();
                                dr["R_idReceta"] = dto_receta.R_idReceta;
                                dr["R_nombreReceta"] = dto_receta.R_nombreReceta;
                                dr["R_numeroPorcion"] = dto_receta.R_numeroPorcion;
                                dr["R_descripcion"] = dto_receta.R_descripcion;
                                dtDisponibles.Rows.Add(dr);
                                recetasDisponibles.Add(dto_receta);
                            }
                        }
                        else
                        {
                            valor = false;
                            break;
                        }
                    }
                    else if (dtIngredientesxReceta.Rows.Count == 0)
                    {
                        dr = dtDisponibles.NewRow();
                        dr["R_idReceta"] = dto_receta.R_idReceta;
                        dr["R_nombreReceta"] = dto_receta.R_nombreReceta;
                        dr["R_numeroPorcion"] = dto_receta.R_numeroPorcion;
                        dr["R_descripcion"] = dto_receta.R_descripcion;
                        dtDisponibles.Rows.Add(dr);
                        break;
                    }


                    j++;

                }

                prueba.Add(dto_receta);
                i++;
            }

            return dtDisponibles;

        }

        public DTO_Receta DAO_Consultar_Receta(int i)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@R_idReceta", i);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                dto_receta.R_idReceta = i;
                dto_receta.R_nombreReceta = reader[1].ToString();
                dto_receta.R_numeroPorcion = Convert.ToInt32(reader[2]);
                dto_receta.R_descripcion = Convert.ToString(reader[3]);
                dto_receta.R_imagenReceta = null;
                try
                {
                    dto_receta.R_imagenReceta = (byte[])reader[4];
                }
                catch (Exception)
                {

                    dto_receta.R_imagenReceta = null;
                }
                
                dto_receta.CR_idCategoriaReceta = Convert.ToInt32(reader[5]);
            }
            conexion.Close();
            return dto_receta;
        }
        public Byte[] Select_ImagenReceta(int R_idReceta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_IMAGEN_RECETA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@R_idReceta", R_idReceta);
            byte[] img = new byte[100];
            img = (byte[])comando.ExecuteScalar();
            conexion.Close();
            return img;
            
        }
        public void actualizarfoto(byte[]aaa,int i)
        {
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Actualizar_foto", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@R_idReceta",i);
            command.Parameters.AddWithValue("@R_imagenReceta",aaa);
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable DAO_ConsultarReceta2()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_RECETA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DataTable DAO_ConsultarRecetaT()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_RECETA_T", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public int SelectIdReceta()
        {
            int idReceta = 0;
             SqlCommand unComando = new SqlCommand("SP_SELECT_ID_RECETA", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                SqlDataReader dReader = unComando.ExecuteReader();
                if (dReader.Read())
                {
                    idReceta = Convert.ToInt32(dReader["R_idReceta"]);
                }
                conexion.Close();
                return idReceta;
           
        }
        public void UpdateReceta(DTO_Receta objDTO)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_UPDATE_RECETA", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@R_idReceta", objDTO.R_idReceta));
                cmd.Parameters.Add(new SqlParameter("@R_nombreReceta", objDTO.R_nombreReceta));
                cmd.Parameters.Add(new SqlParameter("@R_numeroPorcion", objDTO.R_numeroPorcion));
                cmd.Parameters.Add(new SqlParameter("@R_descripcion", objDTO.R_descripcion));
                cmd.Parameters.Add(new SqlParameter("@R_imagenReceta", objDTO.R_imagenReceta));
                cmd.Parameters.Add(new SqlParameter("@R_subcategoria", objDTO.R_subcategoria));
                cmd.Parameters.Add(new SqlParameter("@EP_idEstadoReceta", objDTO.EP_idEstadoReceta));
                cmd.Parameters.Add(new SqlParameter("@CP_idCategoriaReceta", objDTO.CR_idCategoriaReceta));

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public void DeleteReceta(int R_idReceta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_DELETE_RECETA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@R_idReceta", R_idReceta);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable DAO_SelectRecetaTabSegM()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_RECETA_TAB_SEGM", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;

        }
        public DataTable DAO_SelectRecetaTabEntM()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_RECETA_TAB_ENTM", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DataTable DAO_SelectRecetaTabBebM()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_RECETA_TAB_BEBM", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
    }
}
