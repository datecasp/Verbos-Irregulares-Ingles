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
    

    public class VerbosInglesRepositorio {
        
        public List<VerbosIngles> ListaVerbosingles()
        {
            return Datos.DatosList;
        }

    }
}
