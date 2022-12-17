using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Verbos_Irregulares_Inglés.Data;
using Verbos_Irregulares_Inglés.Modelos;
using Verbos_Irregulares_Inglés.Repositorio;

namespace Verbos_Irregulares_Inglés.Servicios
{
    public class VerbosInglesService
    {
        private VerbosInglesRepositorio _verbosInglesRepository = new();
        
        // Número de propiedades de VerbosIngles
        // Castellano, Presente, Pasado y Participio
        private const int tiemposVerbales = 4;
        private int randomAtributo;

        public List<AtributoRandom> GetDatosTabla(List<VerbosIngles> verbosIngles)
        {
            List<AtributoRandom> datosTabla = new List<AtributoRandom>();
            foreach (VerbosIngles verbo in verbosIngles)
            {
                datosTabla.Add(GetAtributoRandom(verbo));
            }
            
            return datosTabla;    
        }

        public List<VerbosIngles> GetListaVerbosInglesService(int numVerbos)
        {
            return _verbosInglesRepository.ListaVerbosingles(numVerbos);
        }

        public AtributoRandom GetAtributoRandom(VerbosIngles verboIngles)
        {
            Random random = new Random();
            randomAtributo = random.Next(tiemposVerbales);

            switch (randomAtributo)
            {
                case 0:
                    return new AtributoRandom() {atributo = verboIngles.Castellano, posicion = 0 };
                case 1:
                    return new AtributoRandom() { atributo = verboIngles.Infinitivo, posicion = 1 };
                case 2:
                     return new AtributoRandom() { atributo = verboIngles.Pasado, posicion = 2 };
                case 3:
                    return new AtributoRandom() { atributo = verboIngles.Participio, posicion = 3 };
                default:
                    return null;
            }
        }

    }
}
