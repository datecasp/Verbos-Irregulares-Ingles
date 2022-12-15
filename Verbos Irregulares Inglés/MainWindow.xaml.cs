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
        private VerbosInglesService _verbosInglesService;
        private RellenarTabla _rellenarTabla;
        private List<AtributoRandom> _randomList;
        public MainWindow()
        {
            InitializeComponent();


        }

        public void RellenarTabla()
        {
            _randomList = _verbosInglesService.GetDatosTabla();
            _rellenarTabla.RellenarTablaUtil(_randomList);
        }
    }
}
