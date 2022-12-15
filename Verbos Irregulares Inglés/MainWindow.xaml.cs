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
        public MainWindow()
        {
            InitializeComponent();

            RellenarTabla();
        }

        public void RellenarTabla()
        {
            _randomList = _verbosInglesService.GetDatosTabla();
            txtCastellano01.Text = _rellenarTabla.SetDatoRandomCelda(_randomList, 0);
            txtCastellano02.Text = _rellenarTabla.SetDatoRandomCelda(_randomList, 0);
            txtCastellano03.Text = _rellenarTabla.SetDatoRandomCelda(_randomList, 0);
            txtCastellano04.Text = _rellenarTabla.SetDatoRandomCelda(_randomList, 0);
            txtCastellano05.Text = _rellenarTabla.SetDatoRandomCelda(_randomList, 1);
            txtCastellano06.Text = _rellenarTabla.SetDatoRandomCelda(_randomList, 1);
            txtCastellano07.Text = _rellenarTabla.SetDatoRandomCelda(_randomList, 1);
            txtCastellano08.Text = _rellenarTabla.SetDatoRandomCelda(_randomList, 1);
        }
    }
}
