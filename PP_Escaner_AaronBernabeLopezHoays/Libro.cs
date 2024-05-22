using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PP_Escaner_AaronBernabeLopezHoays
{
    public class Libro : Documento
    {
        int numPaginas;
        //Constructor
        public Libro(string titulo, string autor, int anio, string NumNoralizador, string barCode, int numPaginas) : base(titulo, autor, anio, NumNoralizador, barCode)
        {
            this.numPaginas = numPaginas;
        }
        //Metodos para acceder a atributos privados
        public int NumPaginas { get => numPaginas; }
        public string numNormalizador { get => NumNormalizador; }

        //Sobrecarga de operadores
        public static bool operator ==(Libro a, Libro b)
        {

            if (a.BarCode == b.BarCode | a.numNormalizador == b.numNormalizador)
            {
                return true;
            }
            else if (a.Titulo == b.Titulo && a.Autor == b.Autor)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Titulo: " + this.Titulo);
            sb.AppendLine("Autor: " + this.Autor);
            sb.AppendLine("Año:" + this.Anio);
            sb.AppendLine("ISBN: " + this.numNormalizador);
            sb.AppendLine("Cod. de barras: " + this.BarCode);
            sb.AppendLine("Numeros de paginas: " + this.numPaginas + ".");

            return sb.ToString();
        }
    }
}
