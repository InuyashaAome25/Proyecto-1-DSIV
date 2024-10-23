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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Bloque de evento click para los botones numericos
            btnCero.Click += new System.EventHandler(this.Numero_Click);
            btnUno.Click += new System.EventHandler(this.Numero_Click);
            btnDos.Click += new System.EventHandler(this.Numero_Click);
            btnTres.Click += new System.EventHandler(this.Numero_Click);
            btnCuatro.Click += new System.EventHandler(this.Numero_Click);
            btnCinco.Click += new System.EventHandler(this.Numero_Click);
            btnSeis.Click += new System.EventHandler(this.Numero_Click);
            btnSiete.Click += new System.EventHandler(this.Numero_Click);
            btnOcho.Click += new System.EventHandler(this.Numero_Click);
            btnNueve.Click += new System.EventHandler(this.Numero_Click);

            //Bloque de evento click para los botones de operadores
            btnSumar.Click += new System.EventHandler(this.Operacion_Click);
            btnRestar.Click += new System.EventHandler(this.Operacion_Click);
            btnMultiplicar.Click += new System.EventHandler(this.Operacion_Click);
            btnDividir.Click += new System.EventHandler(this.Operacion_Click);
            btnExponente.Click += new System.EventHandler(this.Operacion_Click);
            btnRaiz.Click += new System.EventHandler(this.Operacion_Click);
            btnDecimal.Click += new System.EventHandler(this.Operacion_Click);
        }

        private void Numero_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender; // Obtener el botón que fue presionado
            txtDisplay.Text += boton.Text; // Agregar el texto del botón al `TextBox`
        }
        private void Operacion_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender; // Obtener el botón que fue presionado
            txtDisplay.Text += " " + boton.Text + " "; // Agregar el operador al `TextBox` con espacios
        }
    }
}
