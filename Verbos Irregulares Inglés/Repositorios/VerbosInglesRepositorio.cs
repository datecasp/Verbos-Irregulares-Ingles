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
        public List<VerbosIngles> ListaVerbosingles(int numVerbos)
        {
            Random random = new Random();

            randomActual = random.Next(numVerbos);
            //Check not repeating
            if(randomPrevios.Contains(randomActual)) 
            {
                randomActual = random.Next(numVerbos);         
            }
            randomPrevios.Add(randomActual);

            List<VerbosIngles> lista = new List<VerbosIngles>();

            for (int i = 0; i < numVerbos; i++)
            {
                VerbosIngles verbos = listaTotal[random.Next(listaTotal.Count)];
                lista.Add(verbos);
            }
            return lista;
        }

       
    }
}
