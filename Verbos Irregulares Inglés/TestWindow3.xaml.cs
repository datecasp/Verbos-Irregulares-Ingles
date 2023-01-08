using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Verbos_Irregulares_Inglés.Modelos;
using Verbos_Irregulares_Inglés.Utilidades;
using Verbos_Irregulares_Inglés.Servicios;
using System.Windows.Controls;

namespace Verbos_Irregulares_Inglés
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow3 : Window

    {
        List<VerboCell> listaVerboCellMostrada = new();
        private VerbosInglesService _verbosInglesService = new();
        private UtilesLista _utilesLista = new();
        public static List<AtributoRandom> _randomList = new();
        public List<VerbosIngles>? listaVerbos,listaVerbosMostrada = new();
        public List<int> listaCeldasAcertadas = new();
        public List<int> listaCeldasMostradas = new();

        VerboCell? vc, vc1, vc2, vc3, vc0;
        
        // numero de verbos que salen en la pantalla
        public const int NUMVERBOS = 5;

        // numero de verbos totales en la lista
        public const int NUMTOTALVERBOS = 29;

        // numero de tiempos verbales
        public const int TIEMPOS = 4;

        public TestWindow3()
        {

            InitializeComponent();

            RellenarTabla();
        }

        public void RellenarTabla()
        {
            listaVerbos = _verbosInglesService.GetListaVerbosInglesService(NUMTOTALVERBOS, NUMVERBOS);
            _randomList = _verbosInglesService.GetDatosTabla(listaVerbos);
            //Coment para prueba test2
            listaVerbosMostrada = _utilesLista.ResetearLista(listaVerbosMostrada, _randomList.Count);
            listaVerboCellMostrada = _utilesLista.ResetearLista(listaVerboCellMostrada, _randomList.Count);
            vc = new();

            for (int i = 0; i < _randomList.Count; i++)
            {
                switch (_randomList[i].posicion)
                {
                    case 0:
                        listaVerboCellMostrada[i].castellano = _randomList[i].atributo;
                        listaCeldasMostradas.Add((i + 1) * TIEMPOS);
                        vc0 = new VerboCell(_randomList[i].atributo, "","","");
                        listaVerboCellMostrada[i] = vc0;
                        vc.verboLista.Add(vc0);
                        break;
                    case 1:
                        listaVerboCellMostrada[i].infinitivo = _randomList[i].atributo;
                        listaCeldasMostradas.Add((i + 1) * TIEMPOS + _randomList[i].posicion);
                        vc1 = new VerboCell("", _randomList[i].atributo, "", "");
                        listaVerboCellMostrada[i] = vc1;
                        vc.verboLista.Add(vc1);
                        break;
                    case 2:
                        listaVerboCellMostrada[i].pasado = _randomList[i].atributo;
                        listaCeldasMostradas.Add((i + 1) * TIEMPOS + _randomList[i].posicion);
                        vc2 = new VerboCell("", "", _randomList[i].atributo, "");
                        listaVerboCellMostrada[i] = vc2;
                        vc.verboLista.Add(vc2);
                        break;
                    case 3:
                        listaVerboCellMostrada[i].participio = _randomList[i].atributo;
                        listaCeldasMostradas.Add((i + 1) * TIEMPOS + _randomList[i].posicion);
                        vc3 = new VerboCell("", "", "", _randomList[i].atributo);
                        listaVerboCellMostrada[i] = vc3;
                        vc.verboLista.Add(vc3);
                        break;
                    default:
                        break;
                }
            }
            CambiarEnabled(listaCeldasMostradas);
            DataContext = vc;
        }

        private void CambiarEnabled(List<int> listaCeldas)
        {
            foreach (int celda in listaCeldas)
            {
                grdGridTestPrincipal.Children[celda].IsEnabled = !grdGridTestPrincipal.Children[celda].IsEnabled;
            
            }
        }

        public void ComprobarVerbos(object sender, RoutedEventArgs e)
        {
            int aciertos = 0;
            for(int i = 0; i < listaVerbos.Count; i++)
            {
                if(listaVerboCellMostrada[i].castellano.ToLower() == listaVerbos[i].Castellano.ToLower()) 
                { 
                    aciertos++;
                    listaCeldasAcertadas.Add((i + 1 ) * TIEMPOS);
                    
                }
                if(listaVerboCellMostrada[i].infinitivo.ToLower() == listaVerbos[i].Infinitivo.ToLower()) 
                {
                    aciertos++;
                    listaCeldasAcertadas.Add((i + 1) * TIEMPOS + 1);
                }
                if (listaVerboCellMostrada[i].pasado.ToLower() == listaVerbos[i].Pasado.ToLower()) 
                {
                    aciertos++;
                    listaCeldasAcertadas.Add((i + 1) * TIEMPOS + 2);
                }
                if (listaVerboCellMostrada[i].participio.ToLower() == listaVerbos[i].Participio.ToLower()) 
                {
                    aciertos++;
                    listaCeldasAcertadas.Add((i + 1) * TIEMPOS + 3);
                }
            }

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
            for (int item = 0; item < listaVerbos.Count; item++)
            {
                
                if(listaVerboCellMostrada[item].castellano.ToLower() != listaVerbos[item].Castellano.ToLower())
                {
                    vc.verboLista[item].castellano = "E -> " + listaVerboCellMostrada[item].castellano;
                }

                if (listaVerboCellMostrada[item].infinitivo.ToLower() != listaVerbos[item].Infinitivo.ToLower())
                {
                    vc.verboLista[item].infinitivo = "E -> " + listaVerboCellMostrada[item].infinitivo;
                }

                if (listaVerboCellMostrada[item].pasado.ToLower() != listaVerbos[item].Pasado.ToLower())
                {
                    vc.verboLista[item].pasado = "E -> " + listaVerboCellMostrada[item].pasado;
                }

                if (listaVerboCellMostrada[item].participio.ToLower() != listaVerbos[item].Participio.ToLower())
                {
                    vc.verboLista[item].participio = "E -> " + listaVerboCellMostrada[item].participio;
                }
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void VolverJugar(object sender, RoutedEventArgs e)
        {
            CambiarEnabled(listaCeldasMostradas);
            _verbosInglesService.ResetearListaRandoms();
            listaVerbos.Clear();
            listaVerbosMostrada.Clear();
            listaCeldasMostradas.Clear();
            _randomList.Clear();
            RellenarTabla();
        }
    }
}
