using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1_DSIV
{
    internal class OperacionesMat
    {
        public double Suma(double a, double b)
        {
            return a + b;
        }

        public double Restar(double a, double b)
        {
            return a - b;
        }

        public double Multiplicar(double a, double b)
        {
            return a * b;
        }
        public double Dividir(double a, double b)
        {
            if (b != 0)
                return a / b;
            else
                throw new DivideByZeroException("No se puede dividir por cero.");
        }

        public double Raiz(double a)
        {
            return Math.Sqrt(a);
        }

        public double Potencia(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}
