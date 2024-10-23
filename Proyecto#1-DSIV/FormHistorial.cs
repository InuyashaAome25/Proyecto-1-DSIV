using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1_DSIV
{
    public partial class FormHistorial : Form
    {
        public FormHistorial()
        {
            InitializeComponent();
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            clsOperacionesBD historial = new clsOperacionesBD();
            DataTable dt = historial.MostrarCalculos();
            dgvHistorial.DataSource = dt;
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
