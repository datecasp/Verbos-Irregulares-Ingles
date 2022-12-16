using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Verbos_Irregulares_Inglés.Modelos;
using Verbos_Irregulares_Inglés.Utilidades;
using Verbos_Irregulares_Inglés.Servicios;

namespace Verbos_Irregulares_Inglés
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VerbosInglesService _verbosInglesService = new();
        private RellenarTabla _rellenarTabla = new();
        public static List<AtributoRandom> _randomList = new();
        public string[,] arrayDatos2D;
        public VerbosIngles[] arrayVerbos;

        public MainWindow()
        {

            InitializeComponent();
            RellenarTabla();

        }

        public void RellenarTabla()
        {
            // Número de tiempos verbales (columnas)
            int n = 4;
            
            _randomList = _verbosInglesService.GetDatosTabla();
            arrayDatos2D = new string[_randomList.Count, n];
            arrayVerbos = new VerbosIngles[_randomList.Count]; 
            for (int i = 0; i < _randomList.Count; i++)
            {
                // switch tiempos verbales??
                arrayVerbos[i] = _randomList[i].;
            }

            
            //for(int i = 0; i < _randomList.Count; i++)
            //{
            //    arrayDatos2D[i, _randomList[i].posicion] = _randomList[i].atributo;
            //}
            
        }
    }
}
