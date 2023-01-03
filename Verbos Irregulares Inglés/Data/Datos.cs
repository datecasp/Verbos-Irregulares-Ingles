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
        public static List<VerbosIngles> DatosList = new List<VerbosIngles>(new VerbosIngles[29] {
            new VerbosIngles("Caer", "Fall",
                "Fell", "Fallen"),
            new VerbosIngles("Sentir", "Feel",
                "Felt", "Felt"),
            new VerbosIngles("Alimentar", "Feed",
                "Fed", "Fed"),
            new VerbosIngles("Empezar", "Begin",
                "Began", "Begun"),
            new VerbosIngles("Conseguir", "Get",
                "Got", "Got/Gotten"),
            new VerbosIngles("Comer", "Eat",
                "Ate", "Eaten"),
            new VerbosIngles("Hacer", "Do",
                "Did", "Done"),
            new VerbosIngles("Soñar", "Dream",
                "Dreamt", "Dreamt"),
            new VerbosIngles("Ser/Estar", "Is/Are",
                "Was/Were", "Been"),
            new VerbosIngles("Romper", "Break",
                "Broke", "Broken"),
            new VerbosIngles("Traer", "Bring",
                "Brought", "Brought"),
            new VerbosIngles("Construir", "Build",
                "Built", "Built"),
            new VerbosIngles("Comprar", "Buy",
                "Bought", "Bought"),
            new VerbosIngles("Coger", "Catch",
                "Cought", "Cought"),
            new VerbosIngles("Venir", "Come",
                "Came", "Come"),
            new VerbosIngles("Cortar", "Cut",
                "Cut", "Cut"),
            new VerbosIngles("Elegir", "Choose",
                "Chose", "Chosen"),
            new VerbosIngles("Dibujar", "Draw",
                "Drew", "Drawn"),
            new VerbosIngles("Beber", "Drink",
                "Drank", "Drunk"),
            new VerbosIngles("Conducir", "Drive",
                "Drove", "Driven"),
            new VerbosIngles("Pelear", "Fight",
                "Fought", "Fought"),
            new VerbosIngles("Encontrar", "Find",
                "Found", "Found"),
            new VerbosIngles("Volar", "Fly",
                "Flew", "Flown"),
            new VerbosIngles("Olvidar", "Forget",
                "Forgot", "Forgotten"),
            new VerbosIngles("Perdonar", "Forgive",
                "Forgave", "Forgiven"),
            new VerbosIngles("Dar", "Give",
                "Gave", "Given"),
            new VerbosIngles("Ir", "Go",
                "Went", "Gone"),
            new VerbosIngles("Tener", "Have",
                "Had", "Had"),
            new VerbosIngles("Escuchar", "Hear",
                "Heard", "Heard")
        });

        public static char[] abecedario = new char[] { 'a', 'b','c','d','e','f','g','h','i','j','k','l','m'
            ,'n','o','p','q','r','s','t','u','v','w','x','y','z'
        };
    }
}
