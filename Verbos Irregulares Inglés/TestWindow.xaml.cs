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
    public partial class TestWindow : Window
    {
        private VerbosInglesService _verbosInglesService = new();
        private UtilesLista _utilesLista = new();
        public static List<AtributoRandom> _randomList = new();
        public List<VerbosIngles>? listaVerbos,listaVerbosMostrada = new();
        public List<int> listaCeldasAcertadas = new();
        public List<int> listaCeldasMostradas = new();
        
        // numero de verbos que salen en la pantalla
        public const int NUMVERBOS = 5;

        // numero de verbos totales en la lista
        public const int NUMTOTALVERBOS = 29;

        // numero de tiempos verbales
        public const int TIEMPOS = 4;

        public TestWindow()
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


            for (int i = 0; i < _randomList.Count; i++)
            {
                switch (_randomList[i].posicion)
                {
                    case 0:
                        listaVerbosMostrada[i].Castellano = _randomList[i].atributo;
                        listaCeldasMostradas.Add((i + 1) * TIEMPOS);
                        break;
                    case 1:
                        listaVerbosMostrada[i].Infinitivo = _randomList[i].atributo;
                        listaCeldasMostradas.Add(((i + 1) * TIEMPOS) + _randomList[i].posicion);
                        break;
                    case 2:
                        listaVerbosMostrada[i].Pasado = _randomList[i].atributo;
                        listaCeldasMostradas.Add(((i + 1) * TIEMPOS) + _randomList[i].posicion);
                        break;
                    case 3:
                        listaVerbosMostrada[i].Participio = _randomList[i].atributo;
                        listaCeldasMostradas.Add(((i + 1) * TIEMPOS) + _randomList[i].posicion);
                        break;
                    default:
                        break;
                }
            }

            CambiarEnabled(listaCeldasMostradas);
            
            grdGridTestPrincipal.DataContext = listaVerbosMostrada;

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
            for(int i = 0; i < listaVerbosMostrada.Count; i++)
            {
                if(listaVerbosMostrada[i].Castellano.ToLower() == listaVerbos[i].Castellano.ToLower()) 
                {
                    listaVerbosMostrada[i].Castellano = "BIEN -> " + listaVerbosMostrada[i].Castellano;
                    aciertos++;
                    listaCeldasAcertadas.Add((i + 1 ) * TIEMPOS);
                }
                if(listaVerbosMostrada[i].Infinitivo.ToLower() == listaVerbos[i].Infinitivo.ToLower()) 
                {
                    aciertos++;
                    listaCeldasAcertadas.Add((i + 1) * TIEMPOS + 1);
                }
                if (listaVerbosMostrada[i].Pasado.ToLower() == listaVerbos[i].Pasado.ToLower()) 
                {
                    aciertos++;
                    listaCeldasAcertadas.Add((i + 1) * TIEMPOS + 2);
                }
                if (listaVerbosMostrada[i].Participio.ToLower() == listaVerbos[i].Participio.ToLower()) 
                {
                    aciertos++;
                    listaCeldasAcertadas.Add((i + 1) * TIEMPOS + 3);
                }
            }

            // Restamos los aciertos de las celdas rellenas por el programa
            aciertos -= 5;

            //PintaFondos(listaCeldasAcertadas);

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
            //for (int i = 4; i < listaVerbos.Count * 4; i++)
            //{
            //    if (!lista.Contains(i))
            //    {
            //        switch (i)
            //        {
            //            case 4:
            //                txtCastellano01.Style = (Style) FindResource("txt-grid-cells-fallo");
            //                break;

            //        }
            //    }
            //}


            for (int item = 0; item < listaVerbos.Count; item++)
            {
                
                    if(listaVerbosMostrada[item].Castellano.ToLower() != listaVerbos[item].Castellano.ToLower())
                    {
                        TextBox box = new TextBox
                        {
                            Style = (Style)FindResource("txt-grid-cells-fallo"),
                            Text = "ERROR"
                        };
                        grdGridTestPrincipal.Children.RemoveAt((item + 1) * TIEMPOS);
                        grdGridTestPrincipal.Children.Add(box);
                        Grid.SetColumn(box, 0);
                        Grid.SetRow(box, item + 1);
                    listaVerbosMostrada[item].Castellano = "ERROR";
                    }

                    if (listaVerbosMostrada[item].Infinitivo.ToLower() != listaVerbos[item].Infinitivo.ToLower())
                    {
                        TextBox box = new TextBox
                        {
                            Style = (Style)FindResource("txt-grid-cells-fallo"),
                            Text = "ERROR"
                        };
                        grdGridTestPrincipal.Children.RemoveAt((item + 1) * TIEMPOS + 1);
                        grdGridTestPrincipal.Children.Add(box);
                        Grid.SetColumn(box, 1);
                        Grid.SetRow(box, item + 1);
                    listaVerbosMostrada[item].Infinitivo = "ERROR";

                }

                if (listaVerbosMostrada[item].Pasado.ToLower() != listaVerbos[item].Pasado.ToLower())
                    {
                        TextBox box = new TextBox
                        {
                            Style = (Style)FindResource("txt-grid-cells-fallo"),
                            Text = "ERROR"
                        };
                        grdGridTestPrincipal.Children.RemoveAt((item + 1) * TIEMPOS + 2);
                        grdGridTestPrincipal.Children.Add(box);
                        Grid.SetColumn(box, 2);
                        Grid.SetRow(box, item + 1);
                    listaVerbosMostrada[item].Pasado = "ERROR";

                }

                if (listaVerbosMostrada[item].Participio.ToLower() != listaVerbos[item].Participio.ToLower())
                    {
                        TextBox box = new TextBox
                        {
                            Style = (Style)FindResource("txt-grid-cells-fallo"),
                        };
                        grdGridTestPrincipal.Children.RemoveAt((item + 1) * TIEMPOS + 3);
                        grdGridTestPrincipal.Children.Add(box);
                        Grid.SetColumn(box, 3);
                        Grid.SetRow(box, item + 1);
                    
                    listaVerbosMostrada[item].Participio = "ERROR";

                }



            }
            //this.DataContext = null;
            //this.DataContext = listaVerbosMostrada;

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
            listaVerbosMostrada.Clear();
            listaCeldasMostradas.Clear();
            DataContext = null;
            RellenarTabla();
        }
    }
}
