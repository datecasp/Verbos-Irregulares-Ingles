using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verbos_Irregulares_Inglés.Modelos
{
    public enum TiemposEnum
    {
        CASTELLANO,
        PRESENTE,
        PASADO,
        PARTICIPIO
    }

    public class VerbosIngles : IVerbos
    {
        string _castellano;
        string _infinitivo;
        string _pasado;
        string _participio;

        public VerbosIngles()
        {
        }

        public VerbosIngles(string castellano, string infinitivo, string pasado, string participio)
        {
            this._castellano = castellano;
            this._infinitivo = infinitivo;
            this._pasado = pasado;
            this._participio = participio;
        }

        public string Castellano { get { return _castellano; } }
        public string Infinitivo { get { return _infinitivo; } }
        public string Pasado { get { return _pasado; } }
        public string Participio { get { return _participio; } }

    }
}
