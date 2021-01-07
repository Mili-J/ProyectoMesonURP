using System.Data;
using System.Data.SqlClient;
using DTO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace DAO
{
    public class DAO_Movimiento
    {
        DTO_Movimiento dto_movimiento;
        SqlConnection conexion;
        public DAO_Movimiento()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_movimiento = new DTO_Movimiento();
        }
        public void InsertMovimientoGO(DTO_Movimiento objDTO)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_Insertar_Movimiento_GO", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@M_cantidad", objDTO.M_cantidad));
            unComando.Parameters.Add(new SqlParameter("@M_fechaMovimiento", objDTO.M_fechaMovimiento));
            unComando.Parameters.Add(new SqlParameter("@I_idInsumo", objDTO.I_idInsumo));
            unComando.Parameters.Add(new SqlParameter("@U_idUsuario", objDTO.U_idUsuario));

            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public System.Data.DataTable SelectMovimiento(string FechaInicial, string FechaFinal, int Tipo)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_MOVIMIENTOS_X_FECHA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FechaInicial", FechaInicial);
            comando.Parameters.AddWithValue("@FechaFinal", FechaFinal);
            comando.Parameters.AddWithValue("@Tipo", Tipo);
            comando.ExecuteNonQuery();
            System.Data.DataTable dt = new System.Data.DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public void ExportarExcel(string FechaInicial, string FechaFinal, int Tipo) {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                //MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            
            if (FechaFinal == "" && FechaInicial == "" && Tipo == 0)
            {
                xlWorkSheet.Cells[1, 1] = "Movimientos del Mesón del estudiante de la URP";
            }
            else if (Tipo == 1)
            {
                xlWorkSheet.Cells[1, 1] = "Ingresos del Mesón del estudiante de la URP de  " + FechaInicial + "  a  " + FechaFinal;
            }
            else if (FechaFinal == "" && FechaInicial == "" && Tipo == 2)
            {
                xlWorkSheet.Cells[1, 1] = "Egresos del Mesón del estudiante de la URP";
            }
            else if (Tipo == 1) {
                xlWorkSheet.Cells[1, 1] = "Ingresos del Mesón del estudiante de la URP";
            }
            else if (FechaFinal != "" && FechaInicial != "" && Tipo == 0) {
                xlWorkSheet.Cells[1, 1] = "Movimientos del Mesón del estudiante de la URP de  " + FechaInicial + "  a  " + FechaFinal;
            }
            else if(Tipo == 2)
            {
                xlWorkSheet.Cells[1, 1] = "Egresos del Mesón del estudiante de la URP de  " + FechaInicial + "  a  " + FechaFinal;
            }

            xlWorkSheet.Cells[2, 1] = "Insumo";
            xlWorkSheet.Cells[2, 2] = "Cantidad";
            xlWorkSheet.Cells[2, 3] = "Tipo";
            xlWorkSheet.Cells[2, 4] = "Fecha";
            int indice = 3;
            
                conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_MOVIMIENTOS_X_FECHA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FechaInicial", FechaInicial);
            comando.Parameters.AddWithValue("@FechaFinal", FechaFinal);
            comando.Parameters.AddWithValue("@Tipo", Tipo);
            comando.ExecuteNonQuery();
            
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                            //' Cargamos la información en el excel
                            xlWorkSheet.Cells[indice, 1].Value = reader["I_nombreInsumo"];
                            xlWorkSheet.Cells[indice, 2].Value = reader["M_cantidad"];
                            xlWorkSheet.Cells[indice, 3].Value = reader["MT_nombreMovimiento"];
                            xlWorkSheet.Cells[indice, 4].Value = reader["M_fechaMovimiento"];
                            indice += 1;
                    }
                conexion.Close();
            
            xlWorkBook.SaveAs(@"..\Downloads\MesonURP_ConsultarMovimientos.xls", Excel.XlFileFormat.xlExcel8, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlApp.Workbooks.Close();
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }
    }
}

