using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Verbos_Irregulares_Inglés.Modelos;
using Verbos_Irregulares_Inglés.Utilidades;
using Verbos_Irregulares_Inglés.Servicios;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Verbos_Irregulares_Inglés
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow2 : Window

    {
        private List<VerboCell> listaVerbosCellMostrada = new List<VerboCell>();
        


        private VerbosInglesService _verbosInglesService = new();
        private UtilesLista _utilesLista = new();
        public static List<AtributoRandom> _randomList = new();
        public List<VerbosIngles>? listaVerbos;//,listaVerbosMostrada = new();
        public List<int> listaCeldasAcertadas = new();
        public List<int> listaCeldasMostradas = new();
        
        // numero de verbos que salen en la pantalla
        public const int NUMVERBOS = 5;

        // numero de verbos totales en la lista
        public const int NUMTOTALVERBOS = 29;

        // numero de tiempos verbales
        public const int TIEMPOS = 4;

        public TestWindow2()
        {

            InitializeComponent();

            RellenarTabla();

            grdGridTestPrincipal.ItemsSource = listaVerbosCellMostrada;
            
            //CambiarEnabled(listaCeldasMostradas);

        }

        public void RellenarTabla()
        {
            listaVerbos = _verbosInglesService.GetListaVerbosInglesService(NUMTOTALVERBOS, NUMVERBOS);
            _randomList = _verbosInglesService.GetDatosTabla(listaVerbos);
            listaVerbosCellMostrada = _utilesLista.ResetearLista(listaVerbosCellMostrada, _randomList.Count);


            for (int i = 0; i < _randomList.Count; i++)
            {
                switch (_randomList[i].posicion)
                {
                    case 0:
                        listaVerbosCellMostrada[i].castellano = _randomList[i].atributo;
                        listaCeldasMostradas.Add((i + 1) * TIEMPOS);
                        break;
                    case 1:
                        listaVerbosCellMostrada[i].infinitivo = _randomList[i].atributo;
                        listaCeldasMostradas.Add(((i + 1) * TIEMPOS) + _randomList[i].posicion);
                        break;
                    case 2:
                        listaVerbosCellMostrada[i].pasado = _randomList[i].atributo;
                        listaCeldasMostradas.Add(((i + 1) * TIEMPOS) + _randomList[i].posicion);
                        break;
                    case 3:
                        listaVerbosCellMostrada[i].participio = _randomList[i].atributo;
                        listaCeldasMostradas.Add(((i + 1) * TIEMPOS) + _randomList[i].posicion);
                        break;
                    default:
                        break;
                }
            }

            

        }

        private void CambiarEnabled(List<int> listaCeldas)
        {
            for (int i = 0; i < listaCeldas.Count; i++)
            {
                if (!grdGridTestPrincipal.Items[i].Equals(""))
                {
                }
            }
        }

        public void ComprobarVerbos(object sender, RoutedEventArgs e)
        {
            int aciertos = 0;
            for(int i = 0; i < listaVerbosCellMostrada.Count; i++)
            {
                if(listaVerbosCellMostrada[i].castellano.ToLower() == listaVerbos[i].Castellano.ToLower()) 
                { 
                    aciertos++;
                    listaCeldasAcertadas.Add(i + TIEMPOS);
                }
                if(listaVerbosCellMostrada[i].infinitivo.ToLower() == listaVerbos[i].Infinitivo.ToLower()) 
                {
                    aciertos++;
                    listaCeldasAcertadas.Add(i + TIEMPOS + 1);
                }
                if (listaVerbosCellMostrada[i].pasado.ToLower() == listaVerbos[i].Pasado.ToLower()) 
                {
                    aciertos++;
                    listaCeldasAcertadas.Add(i + TIEMPOS + 2);
                }
                if (listaVerbosCellMostrada[i].participio.ToLower() == listaVerbos[i].Participio.ToLower()) 
                {
                    aciertos++;
                    listaCeldasAcertadas.Add(i + TIEMPOS + 3);
                }
            }

            this.DataContext = listaVerbosCellMostrada;

            // Restamos los aciertos de las celdas rellenas por el programa
            aciertos -= 5;

            PintaFondos(listaCeldasAcertadas);

            if(aciertos < 1)
            {
                MessageBox.Show($"Has fallado todos las veces. Sigue y no te desanimes!!");
            }
            else if(aciertos < 2)
            {
                MessageBox.Show($"Has acertado {aciertos} vez y fallado {(listaVerbos.Count*3)-aciertos} veces.");
            }
            else if( aciertos < (listaVerbos.Count*3)-1)
            {
                MessageBox.Show($"Has acertado {aciertos} veces y fallado {(listaVerbos.Count*3) - aciertos} veces.");
            }
            else if (aciertos < (listaVerbos.Count*3))
            {
                MessageBox.Show($"Has acertado {aciertos} veces y fallado {(listaVerbos.Count*3) - aciertos} vez.");
            }
            else
            {
                MessageBox.Show("Has acertado todos las veces!! ENHORABUENA!!");
            }
        }

        public void PintaFondos(List<int> lista)
        {
            for (int i = 0; i < listaVerbos.Count * 3; i++)
                if (!lista.Contains(i + 4))
                {

                }
            
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void VolverJugar(object sender, RoutedEventArgs e)
        {
            //CambiarEnabled(listaCeldasMostradas);
            _randomList.Clear();
            _verbosInglesService.ResetearListaRandoms();
            listaVerbos.Clear();

            listaVerbosCellMostrada.Clear();
            listaCeldasMostradas.Clear();
            DataContext = null;
            RellenarTabla();
        }
    }
}
