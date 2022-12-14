using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbos_Irregulares_Inglés.Modelos;

namespace Verbos_Irregulares_Inglés.Data
{
    public class Datos
    {
        public List<VerbosIngles> DatosList = new List<VerbosIngles>(new VerbosIngles[3] {
            new VerbosIngles("Caer", "Fall",
                "Fell", "Fallen"),
            new VerbosIngles("Sentir", "Feel",
                "Felt", "Felt"),
            new VerbosIngles("Alimentar", "Feed",
                "Fed", "Fed")});


    }
}
