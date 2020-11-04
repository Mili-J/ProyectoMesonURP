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
            try
            {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_INSERT_RECETA", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@R_nombreReceta", objDTO.R_nombreReceta));
                unComando.Parameters.Add(new SqlParameter("@R_numeroPorcion", objDTO.R_numeroPorcion));
                unComando.Parameters.Add(new SqlParameter("@R_imagenReceta", objDTO.R_imagenReceta));
                unComando.Parameters.Add(new SqlParameter("@CR_idCategoriaReceta", objDTO.CR_idCategoriaReceta));
                unComando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
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
        public DataTable DAO_Consultar_Receta_X_Categoria(int categoria)
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
        
        public DataTable DAO_Consultar_Recetas_Disponibles(int racion)
        {
            //TODO
            //<>
            int i = 0;
            DataTable dtRecetas = DAO_Consultar_Recetas(),dtIngredientesxReceta,dtDisponibles = new DataTable();
            DTO_IngredienteXReceta dto_ingredientexreceta;
            DTO_Ingrediente dto_ingrediente;
            object[] recetas, ingredientesxrecetas;
            bool valor=true;
            List<DTO_Receta> recetasDisponibles = new List<DTO_Receta>();
            List<DTO_Receta> prueba = new List<DTO_Receta>();


            while (i<dtRecetas.Rows.Count)
            {
                dto_receta = new DTO_Receta();
                recetas = dtRecetas.Rows[i].ItemArray;            
                dto_receta = DAO_Consultar_Receta(Convert.ToInt32(recetas[0]));
                dtIngredientesxReceta = dao_ingredientexreceta.DAO_Consultar_Insumo_x_Receta(dto_receta);
                int j = 0;
                while (j <dtIngredientesxReceta.Rows.Count&&valor==true)
                {
                    ingredientesxrecetas = dtIngredientesxReceta.Rows[j].ItemArray;
                    dto_ingrediente = dao_ingrediente.DAO_Consultar_IngredienteXID(Convert.ToInt32(ingredientesxrecetas[4]));
                    dto_ingredientexreceta = dao_ingredientexreceta.DAO_Consultar_IngredienteXReceta(Convert.ToInt32(ingredientesxrecetas[3]), Convert.ToInt32(ingredientesxrecetas[4]));
                    if(dto_ingredientexreceta.IR_Cantidad*racion<=dto_ingrediente.I_cantidad)
                    {
                        valor = true;
                        if (j== dtIngredientesxReceta.Rows.Count-1)
                        {

                            recetasDisponibles.Add(dto_receta);
                        }
                    }
                    else
                    {
                        valor = false;
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
                dto_receta.R_imagenReceta = 0;
                dto_receta.CR_idCategoriaReceta = Convert.ToInt32(reader[5]);
            }
            conexion.Close();
            return dto_receta;
        }
    }
}
