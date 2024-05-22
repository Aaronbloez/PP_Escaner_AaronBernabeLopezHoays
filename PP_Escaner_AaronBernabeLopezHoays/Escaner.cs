using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PP_Escaner_AaronBernabeLopezHoays
{
    public class Escaner
    {
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }
        public enum TipoDoc
        {
            Libro,
            Mapa
        }

        //atributos
        List<Documento> listadocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;
        //Metodos para acceder a los atributos privados
        public List<Documento> ListaDocumentos { get => listadocumentos; }
        internal Departamento Locacion { get => locacion; }
        public string Marca { get => marca; }
        internal TipoDoc Tipo { get => tipo; }
        //Constructor
        public Escaner(string marca, TipoDoc tipo)
        {
            this.listadocumentos = new List<Documento>();
            this.marca = marca;
            this.tipo = tipo;
            if (tipo == TipoDoc.Libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else if (tipo == TipoDoc.Mapa)
            {
                this.locacion = Departamento.mapoteca;
            }
            else
            {
                this.locacion = Departamento.nulo;
            }
        }
        //Esta funcion logra que si un documento entra al escaner en el estado de Inicio pase a Distribuido
        public bool CambiarEstadoDocumento(Documento a)
        {
            foreach (Documento item in this.listadocumentos)
            {
                if (item.Estado == Documento.Paso.Inicio)
                {
                    item.AvanzarEstado();
                }
            }
            return false;
        }
        //Sobrecarga de operadores
        public static bool operator ==(Escaner a, Documento b)
        {
            foreach (Documento documento in a.listadocumentos)
            {
                if (documento.GetType() == b.GetType())
                {
                    if (documento == b)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Escaner a, Documento b)
        {
            return !(a == b);
            /*foreach (Documento documento in a.listadocumentos)
            {
                if (documento.GetType() == b.GetType())
                {
                    if (documento == b)
                    {
                        return false;
                    }
                }

            }*/
        }
        //Suma de un libro o un mapa al escaner
        public static bool operator +(Escaner a, Documento b)
        {
            bool tipo = false;
            if (a.listadocumentos.Count <= 0)
            {
                if (a.locacion == Departamento.procesosTecnicos)
                {
                    tipo = true;
                }

                if (a.locacion == Departamento.mapoteca)
                {
                    tipo = true;
                }
            }
            switch (a.locacion)
            {
                case Departamento.procesosTecnicos:
                    foreach (Libro lib in a.listadocumentos)
                    {
                        if (b.NumNormalizador != null)
                        {
                            Libro libroB = b as Libro;
                            tipo = true;
                            if (lib == libroB)
                            {;
                                return false;
                            }
                        }
                    }
                    break;
                case Departamento.mapoteca:
                    foreach (Mapa map in a.listadocumentos)
                    {
                        if (b.NumNormalizador == null)
                        {
                            Mapa mapaB = b as Mapa;
                            tipo = true;
                            if (map == mapaB)
                            {
                                return false;
                            }
                        }

                    }
                    break;
            }
            if (tipo == true)
            {
                if (b.Estado == Documento.Paso.Inicio)
                {
                    b.AvanzarEstado();
                    a.listadocumentos.Add(b);
                    return true;
                }
            }
            return false;
        }
    }
}
