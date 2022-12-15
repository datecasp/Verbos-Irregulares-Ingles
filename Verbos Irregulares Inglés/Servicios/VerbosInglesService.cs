using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbos_Irregulares_Inglés.Modelos;
using Verbos_Irregulares_Inglés.Repositorio;

namespace Verbos_Irregulares_Inglés.Servicios
{
    public class VerbosInglesService
    {
        private DatosRandomService _datosRandomService;
        private VerbosInglesRepositorio _verbosInglesRepository;
        
        // Número de propiedades de VerbosIngles
        // Castellano, Presente, Pasado y Participio
        private int props = 4;

        public List<VerbosIngles> GetListaVerbosInglesService()
        {
            return _verbosInglesRepository.ListaVerbosingles();
        }

        public AtributoRandom GetAtributoRandom(VerbosIngles verboIngles)
        {
            Random random = new Random();
            random.Next(props);
            switch (props)
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

        public List<AtributoRandom> GetDatosTabla()
        {
            List<AtributoRandom> datosTabla = new List<AtributoRandom>();
            List<VerbosIngles> verbosIngles = GetListaVerbosInglesService();
            foreach (VerbosIngles verbo in verbosIngles)
            {
                datosTabla.Add(GetAtributoRandom(verbo));
            }
            return datosTabla;    
        }
    }
}
