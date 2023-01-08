using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbos_Irregulares_Inglés.Modelos;

namespace Verbos_Irregulares_Inglés.Utilidades
{
    public class UtilesLista
    {
        // numero de verbos que salen en la pantalla
        public const int NUMVERBOS = 5;

        // numero de verbos totales en la lista
        public const int NUMTOTALVERBOS = 29;

        // numero de tiempos verbales
        public const int TIEMPOS = 4;

        public List<VerboCell> ResetearLista(List<VerboCell> lista, int numVerbos)
        {
            for (int i = 0; i < numVerbos; i++)
            {
                lista.Add(new VerboCell("", "","","")) ;
                lista[i].castellano = "";
                lista[i].infinitivo = "";
                lista[i].pasado = "";
                lista[i].participio = "";
            }

            return lista;
        }

        public List<VerbosIngles> ResetearLista(List<VerbosIngles> lista, int numVerbos)
        {
            for (int i = 0; i < numVerbos; i++)
            {
                lista.Add(new VerbosIngles("", "", "", ""));
                lista[i].Castellano = "";
                lista[i].Infinitivo = "";
                lista[i].Pasado = "";
                lista[i].Participio = "";
            }

            return lista;
        }

        public string SetDatoRandomCelda(List<AtributoRandom> lista, int numLista)
        {
            switch (lista[numLista].posicion) 
            {
                case 0:
                    return lista[numLista].atributo;
                case 1:
                    return lista[numLista].atributo;
                case 2:
                    return lista[numLista].atributo;
                case 3:
                    return lista[numLista].atributo;
                default:
                    return "";                  
            }
            return lista.Count.ToString();
        }
    }
}
