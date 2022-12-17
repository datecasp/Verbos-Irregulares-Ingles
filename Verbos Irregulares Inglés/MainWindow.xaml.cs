using System.Collections.Generic;
using System.Linq;
using System.Windows;
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
        private UtilesLista _utilesLista = new();
        public static List<AtributoRandom> _randomList = new();
        public List<VerbosIngles>? listaVerbosCompleta,listaVerbos;
        public const int NUMVERBOS = 5;

        public MainWindow()
        {

            InitializeComponent();

            RellenarTabla();

        }

        public void RellenarTabla()
        {
            listaVerbosCompleta = _verbosInglesService.GetListaVerbosInglesService(NUMVERBOS);
            _randomList = _verbosInglesService.GetDatosTabla(listaVerbosCompleta);
            listaVerbos = new List<VerbosIngles>();
            listaVerbos = _utilesLista.ResetearLista(listaVerbos, _randomList.Count);


            for (int i = 0; i < _randomList.Count; i++)
            {
                switch (_randomList[i].posicion)
                {
                    case 0:
                        listaVerbos[i].Castellano = _randomList[i].atributo;
                        break;
                    case 1:
                        listaVerbos[i].Infinitivo = _randomList[i].atributo;
                        break;
                    case 2:
                        listaVerbos[i].Pasado = _randomList[i].atributo; 
                        break;
                    case 3:
                        listaVerbos[i].Participio = _randomList[i].atributo;
                        break;
                    default:
                        break;
                }
            }

            this.DataContext = listaVerbos;

        }

        public void ComprobarVerbos(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < listaVerbos.Count; i++)
            {
                if(listaVerbos[i].Castellano == listaVerbosCompleta[i].Castellano
                    && listaVerbos[i].Infinitivo == listaVerbosCompleta[i].Infinitivo
                    && listaVerbos[i].Pasado == listaVerbosCompleta[i].Pasado
                    && listaVerbos[i].Participio == listaVerbosCompleta[i].Participio)
                {
                    MessageBox.Show("Correcto!");
                }
                else
                {
                    MessageBox.Show("Fallaste algo!");
                }
            }
        }
    }
}
