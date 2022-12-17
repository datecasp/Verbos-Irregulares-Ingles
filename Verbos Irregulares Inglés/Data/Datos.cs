using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbos_Irregulares_Inglés.Modelos;

namespace Verbos_Irregulares_Inglés.Data
{
    public static class Datos
    {
        public static List<VerbosIngles> DatosList = new List<VerbosIngles>(new VerbosIngles[6] {
            new VerbosIngles("Caer", "Fall",
                "Fell", "Fallen"),
            new VerbosIngles("Sentir", "Feel",
                "Felt", "Felt"),
            new VerbosIngles("Alimentar", "Feed",
                "Fed", "Fed"),
            new VerbosIngles("Empezar", "Begin",
                "Begun", "Began"),
            new VerbosIngles("Conseguir", "Get",
                "Got", "Gotten"),
            new VerbosIngles("Comer", "Eat",
                "Ate", "Eaten")});


    }
}
