using System;
using System.Data;
using System.Windows.Forms;

namespace prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet ds;
        string consulta;
        private void Form1_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consulta = "INSERT INTO nombre (nombre,apellido) VALUES ('" + txtnombre.Text + "','" + txtapellido.Text + "');";
            conexionBD.InsertarModificar(consulta);

            Mostrar();
        }

        private void Mostrar()
        {
            consulta = "SELECT * FROM nombre";
            conexionBD.MostrarTabla(ds, dataGridView1, consulta);
            txtnombre.Text = "";
            txtapellido.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            consulta = "UPDATE nombre SET nombre='" + txtnombre.Text + "',apellido='" + txtapellido.Text + "' WHERE id = " + txtid.Text;
            conexionBD.InsertarModificar(consulta);
            Mostrar();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            consulta = "DELETE FROM nombre WHERE id=" + dataGridView1.SelectedCells[0].Value;
            conexionBD.InsertarModificar(consulta);
            Mostrar();
        }
    }
}