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
            btnCE.Click += new System.EventHandler(this.btnCE_Click);
            btnC.Click += new System.EventHandler(this.btnC_Click);

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
            btnRaiz.Click += new System.EventHandler(this.Raiz_Click);
            btnDecimal.Click += new System.EventHandler(this.Decimal_Click);
            btnNegativo.Click += new System.EventHandler(this.Negativo_Click); // Botón de negativo/positivo

            btnParentesisAbre.Click += new System.EventHandler(this.Parentesis_Click); // Añadir evento click para paréntesis de apertura
            btnParentesisCierra.Click += new System.EventHandler(this.Parentesis_Click); // Añadir evento click para paréntesis de cierre
            btnRaizCubica.Click += new System.EventHandler(this.RaizCubica_Click);
        }
        double valor1, valor2; // Variables para almacenar los valores de las operaciones
        string operacion;      // Variable para almacenar la operación actual

        //Variable global
        private clsOperacionesBD historial = new clsOperacionesBD();
        private OperacionesMat operaciones = new OperacionesMat();

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            valor1 = 0;
            valor2 = 0;
            operacion = string.Empty;
        }
        private void MostrarHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHistorial formHistorial = new FormHistorial();
            formHistorial.Show();
            this.Hide();
        }

        private void Decimal_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void Negativo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                if (txtDisplay.Text.StartsWith("-"))
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(1);
                }
                else
                {
                    txtDisplay.Text = "-" + txtDisplay.Text;
                }
            }
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            string expresion = txtDisplay.Text;
            try
            {
                double resultado = EvaluarYCalcular(expresion);
                txtDisplay.Text = resultado.ToString();

                // Determinar el operador
                string operador = ObtenerOperador(expresion);

                // Guardar la operación en la base de datos
                historial.GuardarCalculo(expresion, resultado.ToString(), operador);
            }
            catch (Exception ex)
            {
                txtDisplay.Text = "Error";
            }
        }
        private double EvaluarYCalcular(string expresion)
        {
            try
            {
                var tabla = new DataTable();
                var resultado = tabla.Compute(expresion, string.Empty);
                return Convert.ToDouble(resultado);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Expresión inválida", ex);
            }
        }
        private string ObtenerOperador(string expresion)
        {
            if (expresion.Contains("(") || expresion.Contains(")"))
            {
                return "COMBINADA";
            }
            if (expresion.Contains("+")) return "SUMA";
            else if (expresion.Contains("-")) return "RESTA";
            else if (expresion.Contains("*")) return "MULTIPLICACIÓN";
            else if (expresion.Contains("/")) return "DIVISIÓN";
            else if (expresion.Contains("^")) return "POTENCIA";
            else if (expresion.Contains("√")) return "RAÍZ CUADRADA";
            else if (expresion.Contains("∛")) return "RAÍZ CÚBICA";
            return "DESCONOCIDO";
        }

        private void Raiz_Click(object sender, EventArgs e)
        {
            try
            {
                double valor = Convert.ToDouble(txtDisplay.Text);
                double resultado = operaciones.Raiz(valor);
                txtDisplay.Text = resultado.ToString();

                // Guardar la operación en la base de datos
                string operador = "RAÍZ CUADRADA";
                string expresion = "√" + valor;
                historial.GuardarCalculo(expresion, resultado.ToString(), operador);
            }
            catch (Exception ex)
            {
                txtDisplay.Text = "Error";
            }
        }
        private void Parentesis_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender; // Obtener el botón que fue presionado
            txtDisplay.Text += boton.Text; // Agregar el texto del botón al `TextBox`
        }

        private void RaizCubica_Click(object sender, EventArgs e)
        {
            try
            {
                double valor = Convert.ToDouble(txtDisplay.Text);
                double resultado = operaciones.RaizCubica(valor); // Usa la función personalizada
                txtDisplay.Text = resultado.ToString();
                // Guardar la operación en la base de datos
                string operador = "RAÍZ CÚBICA";
                string expresion = "∛" + valor;
                historial.GuardarCalculo(expresion, resultado.ToString(), operador);
            }
            catch (Exception ex)
            {
                txtDisplay.Text = "Error";
            }
        }

    }
}
