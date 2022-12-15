using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbos_Irregulares_Inglés.Data;
using Verbos_Irregulares_Inglés.Modelos;

namespace Verbos_Irregulares_Inglés.Repositorio

{
    

    public class VerbosInglesRepositorio {
        private Datos _datos;
        public List<VerbosIngles> ListaVerbosingles()
        {
            return _datos.DatosList;
        }

    }
}
