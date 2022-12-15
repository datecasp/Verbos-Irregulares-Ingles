﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Verbos_Irregulares_Inglés.Data;
using Verbos_Irregulares_Inglés.Repositorio;

namespace Verbos_Irregulares_Inglés.Servicios
{
    public class DatosRandomService : IDatosRandomService
    {
        private VerbosInglesRepositorio _verbosInglesRepositorio;
        public List<VerbosInglesRepositorio> _verbosInglesList;

        public DatosRandomService(VerbosInglesRepositorio verbosIngles) 
        {
            _verbosInglesRepositorio = verbosIngles;
        }

        public VerbosInglesRepositorio VerbosIngles { get { return _verbosInglesRepositorio; } }


    }
}
