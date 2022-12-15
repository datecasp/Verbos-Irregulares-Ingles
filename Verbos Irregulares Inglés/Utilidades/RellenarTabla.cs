using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbos_Irregulares_Inglés.Modelos;

namespace Verbos_Irregulares_Inglés.Utilidades
{
    public class RellenarTabla
    {
        public string SetDatoRandomCelda(List<AtributoRandom> lista, int numLista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                //if(i == 0) 
                //{
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
                //}
            }

            return lista.Count.ToString();
        }
    }
}
