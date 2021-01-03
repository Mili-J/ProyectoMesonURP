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
    public class DAO_MenuXReceta
    {
        SqlConnection conexion;
        
        public DAO_MenuXReceta()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public void DAO_RegistrarMenuXReceta(DTO_MenuXReceta obj)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_RegistrarMenuXReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@R_idReceta", obj.R_idReceta);
            comando.Parameters.AddWithValue("@ME_idMenu", obj.ME_idMenu);
            comando.Parameters.AddWithValue("@MXR_numeroPorcion", obj.MXR_numeroPorcion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable DAO_ConsultarRecetasXMenu(int i)//Consultar las recetas de un menu
        {
            DataTable dtMXR = new DataTable();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarMenuXReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_idMenu",i);
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dtMXR);
            conexion.Close();
            return dtMXR;
        }
        public DataTable DAO_ConsultarRecetasXMenuYCategoria(int M_id,int Cat_id)//Consultar las recetas de un menu
        {
            DataTable dtMXR = new DataTable();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarMenuXRecetaYCategoria", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_idMenu", M_id);
            comando.Parameters.AddWithValue("@CP_idCategoriaReceta", Cat_id);
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dtMXR);
            conexion.Close();
            return dtMXR;
        }
        
        public void DAO_ActualizarMenuXReceta(DataTable dtMenuReceta)
        {
           
           // DataTable dtMX = DAO_ConsultarRecetasXMenu(menu.ME_idMenu);
            int j = 0;
            object[] recetasMenu;
            DTO_MenuXReceta obj=new DTO_MenuXReceta();
            while (j< dtMenuReceta.Rows.Count)
            {
                recetasMenu = dtMenuReceta.Rows[j].ItemArray;
                obj.MXR_idMenuReceta = Convert.ToInt32(recetasMenu[0]);
                obj.R_idReceta = Convert.ToInt32(recetasMenu[1]);
                obj.ME_idMenu = Convert.ToInt32(recetasMenu[2]);
                DAO_ActualizarUnMenuXReceta(obj);

                j++;
            }
         
        }
        public void DAO_ActualizarUnMenuXReceta(DTO_MenuXReceta menureceta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ActualizarMenuXReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@R_idReceta", menureceta.R_idReceta);
            comando.Parameters.AddWithValue("@MXR_idMenuReceta",menureceta.MXR_idMenuReceta);
            comando.Parameters.AddWithValue("@ME_idMenu", menureceta.ME_idMenu);
            comando.Parameters.AddWithValue("@MXR_numeroPorcion", menureceta.MXR_numeroPorcion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public DTO_MenuXReceta DAO_ConsultarMenuXReceta(int i)//Solo uno, IDMenuXreceta
        {
            DTO_MenuXReceta obj= new DTO_MenuXReceta();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarSoloUnMenuXReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@MXR_idMenuReceta", i);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                obj.MXR_idMenuReceta = Convert.ToInt32(reader[0]);
                obj.R_idReceta = Convert.ToInt32(reader[1]);
                obj.ME_idMenu = Convert.ToInt32(reader[2]);
            }
            conexion.Close();
            return obj;
        }
        public void DAO_EliminarMenusXReceta(int id)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_EliminarMenuXRecetas", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_idMenu", id);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        
        public void DAO_EliminarMenu(int id)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_EliminarMenu", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_idMenu", id);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public bool SelectExistenciaMenuxReceta(int R_idReceta, string Fecha)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_SELECT_EXISTENCIA_MENU_X_RECETA", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@R_idReceta", R_idReceta);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.ExecuteNonQuery();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
       
    }
}
