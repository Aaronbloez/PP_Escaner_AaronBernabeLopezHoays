using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Escaner_AaronBernabeLopezHoays
{
    public class Mapa : Documento
    {
        /// <summary>
        /// 
        /// </summary>
        int alto;
        int ancho;

        public Mapa(string titulo, string autor, int anio, string numNormalizador, string barCode, int alto, int ancho) : base(titulo, autor, anio, numNormalizador, barCode)
        {
            this.alto = alto;
            this.ancho = ancho;
            this.numNormalizador = null;
        }
        //Metodos para acceder a atributos privados
        public int Alto { get => alto; }
        public int Ancho { get => ancho; }
        public int Superficie { get => ancho * alto; }
        //Sobrecarga de los operadores
        public static bool operator ==(Mapa a, Mapa b)
        {
            if (a.BarCode == b.BarCode)
            {
                return true;
            }
            if (a.Titulo == b.Titulo && a.Autor == b.Autor && a.Superficie == b.Superficie)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Mapa a, Mapa b)
        {
            return !(a == b);
        }

        //Metodo Tostring: Retorna un string para lecutara de datos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Titulo: " + this.Titulo);
            sb.AppendLine("Autor: " + this.Autor);
            sb.AppendLine("Año: " + this.Anio);
            sb.AppendLine("Cod. de barras: " + this.BarCode);
            sb.AppendLine("Superficie: " + this.alto + " * " + this.ancho + " = " + this.Superficie + "cm2");
            return sb.ToString();
        }

    }
}
