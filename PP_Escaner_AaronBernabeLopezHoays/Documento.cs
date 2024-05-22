using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Escaner_AaronBernabeLopezHoays
{
    public abstract class Documento
    {
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }
        //atributos
        int anio;
        string autor;
        string barCode;
        Paso estado;
        protected string numNormalizador;
        string titulo;
        //constructor
        protected Documento(string titulo, string autor, int anio, string numNormalizador, string barCode)
        {
            this.anio = anio;
            this.autor = autor;
            this.barCode = barCode;
            this.estado = Paso.Inicio;
            this.numNormalizador = numNormalizador;
            this.titulo = titulo;
        }

        //metodos para acceder a atributos privados
        public int Anio { get => anio; }
        public string Autor { get => autor; }
        public string BarCode { get => barCode; }
        public Paso Estado { get => estado; }
        internal protected string NumNormalizador { get => numNormalizador; }
        public string Titulo { get => titulo; }

        //Esta funcion permite cambiar el estado al al siguiente
        public bool AvanzarEstado()
        {
            switch (this.estado)
            {
                case Paso.Inicio:
                    this.estado = Paso.Distribuido;
                    break;
                case Paso.Distribuido:
                    this.estado = Paso.EnEscaner;
                    break;
                case Paso.EnEscaner:
                    this.estado = Paso.EnRevision;
                    break;
                case Paso.EnRevision:
                    this.estado = Paso.Terminado;
                    break;
                case Paso.Terminado:
                    return false;


            }
            return true;

        }
        //Funcion ToString: Permite retornar un string con los datos del documento
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Titulo: " + this.titulo);
            sb.AppendLine("Autor: " + this.autor);
            sb.AppendLine("Anio: " + this.anio);
            sb.AppendLine("Estado: " + this.estado);
            sb.AppendLine("Cod. de barras: " + this.barCode);
            sb.AppendLine("ISBN :" + this.numNormalizador);
            return sb.ToString();
        }
    }


}
