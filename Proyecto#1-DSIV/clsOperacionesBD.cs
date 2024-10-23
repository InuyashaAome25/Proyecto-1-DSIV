using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1_DSIV
{
    internal class clsOperacionesBD
    {
        string connectionString = @"Server=Cesar-Castillo44;Database=DBCalculadoraProyect;TrustServerCertificate=true;Integrated Security=SSPI;";
        public void GuardarCalculo(string operacion, string resultado, string operador)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "InsertarCalculo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", operacion);
                    cmd.Parameters.AddWithValue("@Resultado", resultado);
                    cmd.Parameters.AddWithValue("@Operador", operador);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable MostrarCalculos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "MostrarCalculos";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
