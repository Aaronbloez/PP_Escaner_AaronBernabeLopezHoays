using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Escaner_AaronBernabeLopezHoays
{
    public static class Informes
    {
        //Metodos estaticos para mostrar datos en consola
        private static void MostrarDocumentosPorEstados(Escaner e, Documento.Paso paso, out int extencion, out int cantidad, out string resumen)
        {
            cantidad = 0;
            extencion = 0;
            resumen = "";
            StringBuilder stringBuilder = new StringBuilder();
            switch (e.Tipo)
            {
                case Escaner.TipoDoc.Libro:
                    foreach (Libro lib in e.ListaDocumentos)
                    {
                        if (lib.Estado == paso)
                        {
                            cantidad++;
                            extencion += lib.NumPaginas;
                            stringBuilder.AppendLine(lib.ToString());
                            stringBuilder.AppendLine("");
                            stringBuilder.AppendLine("");
                        }
                    }
                    resumen = stringBuilder.ToString();

                    break;
                case Escaner.TipoDoc.Mapa:
                    foreach (Mapa lib in e.ListaDocumentos)
                    {
                        if (lib.Estado == paso)
                        {
                            cantidad++;
                            extencion += lib.Superficie;
                            stringBuilder.AppendLine(lib.ToString());
                            stringBuilder.AppendLine("");
                            stringBuilder.AppendLine("");
                        }

                    }
                    resumen = stringBuilder.ToString();
                    break;

            }
        }
        public static void MostrarDistribuidos(Escaner e, out int extencion, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstados(e, Documento.Paso.Distribuido, out extencion, out cantidad, out resumen);
        }
        public static void MostrarEnEscaner(Escaner e, out int extencion, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstados(e, Documento.Paso.EnEscaner, out extencion, out cantidad, out resumen);
        }
        public static void MostrarEnRevision(Escaner e, out int extencion, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstados(e, Documento.Paso.EnRevision, out extencion, out cantidad, out resumen);

        }
        public static void MostrarTerminados(Escaner e, out int extencion, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstados(e, Documento.Paso.Terminado, out extencion, out cantidad, out resumen);
        }




    }
}
