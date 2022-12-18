using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Verbos_Irregulares_Inglés.Data;
using Verbos_Irregulares_Inglés.Modelos;

namespace Verbos_Irregulares_Inglés.Repositorio

{
    

    public class VerbosInglesRepositorio 
    {
        private List<VerbosIngles> listaTotal = Datos.DatosList;
        private List<int> randomPrevios = new List<int>();
        private int randomActual = 0;
        public List<VerbosIngles> ListaVerbosIngles(int totalVerbos, int numVerbos)
        {
            Random random = new Random();
            List<VerbosIngles> lista = new List<VerbosIngles>();

            for (int i = 0; i < numVerbos; i++)
            {
                //Check not repeating
                do
                {
                    randomActual = random.Next(totalVerbos);

                } while (randomPrevios.Contains(randomActual));

                randomPrevios.Add(randomActual);

                VerbosIngles verbos = listaTotal[randomActual];
                lista.Add(verbos);
            }
            return lista;
        }

        public void ResetearListaRandoms()
        {
            randomPrevios.Clear();
        }
    }
}
