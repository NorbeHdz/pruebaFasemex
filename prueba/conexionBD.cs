using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace prueba
{
    public class conexionBD
    {
        private static SqlConnection sqlconexion = new SqlConnection("SERVER = localhost\\SQLEXPRESS;database = prueba; TRUSTED_CONNECTION = TRUE;");

        public static void MostrarTabla (DataSet ds, DataGridView data,string consulta)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(consulta, sqlconexion);
                ds = new DataSet();
                da.Fill(ds, "nombres");
                data.DataSource = ds.Tables["nombres"];
                data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar a la base de datos");
            }
           
        }

        public static void InsertarModificar (string consulta)
        {
            try
            {
                SqlCommand comando = new SqlCommand(consulta, sqlconexion);
                sqlconexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
            sqlconexion.Close();
        }
    }
}
