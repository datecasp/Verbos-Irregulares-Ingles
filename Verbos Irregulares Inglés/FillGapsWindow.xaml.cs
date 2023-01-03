using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Verbos_Irregulares_Inglés.Modelos;
using Verbos_Irregulares_Inglés.Servicios;

namespace Verbos_Irregulares_Inglés
{
    /// <summary>
    /// Lógica de interacción para PlayWindow.xaml
    /// </summary>
    public partial class FillGapsWindow : Window
    {
        private VerbosInglesService _verbosInglesService = new();
        public VerbosIngles verboIngles = new ();
        public AtributoRandom atrRandomCompleta = new();
        public AtributoRandom atrRandomGap = new();
        public int posRandom = 0;

        public Button[] palabraGapButtons;
        public Button[] letrasAzarButtons;
        public string palabraCompleta = "";
        public string palabraGap = "";
        public char[] palabraGapChar;
        public char[] palabraGapPistasChar;
        public char[] letrasAzarChar;

        public bool rendirse = false; // flag funcionalidad rendirse
        public string letraButton = "";

        public FillGapsWindow()
        {
            InitializeComponent();
            
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            grdFillIntro.Visibility = Visibility.Hidden;
            grdFillGame.Visibility = Visibility.Visible;
            grdFillLetrasAzar.Visibility = Visibility.Visible;
            btnPlay.Content = "Otra palabra";
            verboIngles = _verbosInglesService.GetListaVerbosInglesService(29, 1).First();
            atrRandomCompleta = _verbosInglesService.GetAtributoRandom(verboIngles);
            palabraCompleta = atrRandomCompleta.atributo;
            do
            {
                atrRandomGap = _verbosInglesService.GetAtributoRandom(verboIngles);
            } while (atrRandomGap.posicion == atrRandomCompleta.posicion);

            palabraGap = atrRandomGap.atributo;
            palabraGapChar = palabraGap.ToLower().ToCharArray();
            palabraGapPistasChar = preparaPalabraGapChar(palabraGapChar);
            letrasAzarChar = completaArrayLetrasAzar(palabraGapPistasChar, palabraGapChar);
            letrasAzarChar = mezclaArrayLetrasAzar(letrasAzarChar);

            txtPlayGameCompleta.Text = $"The complete word in {getTiempoVerbal(atrRandomCompleta.posicion)} is {palabraCompleta}";
            txtPlayGameGap.Text = $"The gapped word in {getTiempoVerbal(atrRandomGap.posicion)} is...";
            
            
            pintaBtnGrids(creaGridPalabraGap(palabraGapChar), ref palabraGapButtons, palabraGapPistasChar, "pistas", rendirse);
            pintaBtnGrids(creaGridLetrasAzar(letrasAzarChar), ref letrasAzarButtons, letrasAzarChar, "azar", rendirse);
        }

        private string getTiempoVerbal(int posicion)
        {
            switch (posicion)
            {
                case 0: 
                    return "Spanish"; 
                    break;
                case 1:
                    return "Present";
                    break;
                case 2:
                    return "Past";
                    break;
                case 3:
                    return "Participle";
                    break;
                default:
                    break;

            }
            return "";
        }

        private char[] preparaPalabraGapChar(char[] palabraGapChar)
        {
            char[] result = new char[palabraGapChar.Length];
            Random rd = new Random();
            if(palabraGapChar.Length > 2)
            {
                for (int i = 0; i < palabraGapChar.Length / 2; i++)
                {
                    if (!Char.IsLetter(palabraGapChar[i])) 
                    { 
                        result[i] = palabraGapChar[i]; 
                    }
                    else
                    {
                        int index = rd.Next(palabraGapChar.Length);
                        result[index] = palabraGapChar[index];
                    }
                }
            }
            return result;
        }

        private char[] completaArrayLetrasAzar(char[] arrayLetrasAzarInicial, char[] palabraGapChar)
        {
            Random rd = new Random();
            int numLetrasFinal = 0;

            if (arrayLetrasAzarInicial.Length <= 4)
            {
                numLetrasFinal = 6;
            }
            else if (4 < arrayLetrasAzarInicial.Length && arrayLetrasAzarInicial.Length <= 6)
            {
                numLetrasFinal = 8;
            }
            else
            {
                numLetrasFinal = 10;
            }
            char[] result = new char[numLetrasFinal];
            for (int i = 0; i < numLetrasFinal; i++)
            {
                if (i < arrayLetrasAzarInicial.Length && arrayLetrasAzarInicial[i] != palabraGapChar[i])
                {
                    result[i] = palabraGapChar[i];
                }
                else
                {
                    result[i] = Data.Datos.abecedario[rd.Next(Data.Datos.abecedario.Length)];
                }
            }
            return result;
        }

        private char[] mezclaArrayLetrasAzar(char[] letrasAzarArrayChar)
        {
            Random rd = new Random();
            char[] result = new char[letrasAzarArrayChar.Length];
            ArrayList temporal = new ArrayList();
            foreach(char c in letrasAzarArrayChar)
            {
                temporal.Add(c);
            }
            for (int i = 0; i < result.Length; i++)
            {
                int index = rd.Next(temporal.Count);
                result[i] = (char)temporal[index];
                temporal.RemoveAt(index);
            }
            return result;
        }

        /**
         * 
         *  Crea Grid para los Buttons con las letras aleatorias de la palabra a encontrar
         * 
         */
        private Grid creaGridPalabraGap(char[] palabraGapChar)
        {
            Grid grdPlayBtnLetters = new Grid();
            grdPlayBtnLetters.Margin = new Thickness(0, 175, 0, 0);
            grdPlayBtnLetters.VerticalAlignment = VerticalAlignment.Top;
            grdPlayBtnLetters.HorizontalAlignment = HorizontalAlignment.Center;
            grdFillGame.Children.Add(grdPlayBtnLetters);
            if(grdFillGame.Children.Count > 3)
            {
                grdFillGame.Children[grdFillGame.Children.Count - 2].Visibility = Visibility.Hidden;
            }
            grdPlayBtnLetters.Width = (palabraGapChar.Length + 1) * 55;
            return grdPlayBtnLetters;
        }

        /**
         * 
         *  Crea Grid para los Buttons de las letras al azar de las que elegir
         * 
         */
        private Grid creaGridLetrasAzar(char[] letrasArrayChar)
        {
            Grid grdLetrasAzar = new Grid();
            grdLetrasAzar.Margin = new Thickness(0, 0, 0, 50);
            grdLetrasAzar.VerticalAlignment = VerticalAlignment.Bottom;
            grdLetrasAzar.HorizontalAlignment = HorizontalAlignment.Center;
            grdFillLetrasAzar.Children.Add(grdLetrasAzar);
            if (grdFillLetrasAzar.Children.Count > 1)
            {
                grdFillLetrasAzar.Children[grdFillLetrasAzar.Children.Count - 2].Visibility = Visibility.Hidden;
            }
            grdLetrasAzar.Width = (letrasArrayChar.Length + 1) * 55;
            return grdLetrasAzar;
        }

        /**
         * 
         *  private void pintaBtnGrids(Grid gridLetters, ref Button[] charButtons
            ,char[] arrayChars, string flagTipoBtn, bool rendirse)
         *  
         *  Pinta los Grids de Buttons
         *  
         *  @param ->
         *      + gridLetters - Referencia al grid contenedor de todo
         *      + charButtons - Array de Buttons a pintar
         *      + arrayChars - Letras a pintar en los Buttons
         *      + flagTipoBtn - Flag diferenciador entre los dos Grids del layout
         *      + rendirse - Flag para mostrar la palabra en caso de rendición 
         *  
         */
        private void pintaBtnGrids(Grid gridLetters, ref Button[] charButtons
            ,char[] arrayChars, string flagTipoBtn, bool rendirse)
        {
            if (!rendirse)
            {
                charButtons = new Button[arrayChars.Length];
                for (int i = arrayChars.GetLowerBound(0); i <= arrayChars.GetUpperBound(0); i++)
                {
                    gridLetters.ColumnDefinitions.Add(new ColumnDefinition());

                    if (flagTipoBtn.Equals("pistas"))
                    {
                        charButtons[i] = this.Resources["btnPlayPistas"] as Button;
                        charButtons[i].Content = arrayChars[i];
                        if (Char.IsLetter((char)charButtons[i].Content))
                        {
                            charButtons[i].IsEnabled = false;
                        }
                    }
                    else if (flagTipoBtn.Equals("azar"))
                    {
                        charButtons[i] = this.Resources["btnPlayAzar"] as Button;
                        charButtons[i].Content = arrayChars[i];
                    }

                    Grid.SetColumn(charButtons[i], i);
                    gridLetters.Children.Add(charButtons[i]);
                }
            }
            else  //Funcionalidad para que muestre la palabra si te rindes
            {
                for (int i = arrayChars.GetLowerBound(0); i <= arrayChars.GetUpperBound(0); i++)
                {

                    //Pintar palabraGapButtons con palabraArrayChar
                }

            }
        }

        /**
         *  void btn_ClickedPista (object sender, RoutedEventArgs e)
         *  
         *  Método Click de los Buttons del Grid palabraGapButtons
         *  
         *  Muestra la letra seleccionada de letrasAzarButtons en el 
         *  
         *  Button seleccionado de palabraGapButtons.
         *  
         *  Si no ha seleccionado antes una letra de letrasAzar muestra
         *  
         *  MessageBox con advertencia
         */
        public void btn_ClickedPista (object sender, RoutedEventArgs e)
        {
            if(letraButton == "")
            {
                MessageBox.Show("Selecciona primero una letra");
            }
            else
            {
                ((Button)sender).Content = letraButton;
                letraButton = "";
                chequeaPalabraGapButtons();
            }
        }

        /**
         *  Comprueba si los Buttons de palabraGapButtons tienen todos
         *  
         *  Content asigando y en caso afirmativo comprueba si son
         *  
         *  iguales a la referencia de palabraArrayChar original
         */
        private void chequeaPalabraGapButtons()
        {
            int completa = 0;
            bool bien = true;
            char[] respuesta = new char[palabraGapChar.Length];
            for (int i = 0; i < palabraGapChar.Length; i++)
            {
                
                if(Char.IsLetter(char.Parse(palabraGapButtons[i].Content.ToString())))
                {
                    respuesta[i] = char.Parse(palabraGapButtons[i].Content.ToString());
                    completa ++;
                }
            }
            if (completa == palabraGapChar.Length)
            {
                for(int i = 0; i < palabraGapChar.Length; i++)
                {
                    if (!respuesta[i].Equals(palabraGapChar[i]))
                    {
                        bien = false;
                    }                  
                }
                if (bien)
                {
                    MessageBox.Show("OUIEAS Bien hecho!!");
                }
                else
                {
                    MessageBox.Show("Vuelve a intentarlo.");
                }
            }
        }


        /**
         *  Método Click de los Buttons de letrasAzarButtons
         *  
         *  Guarda en la variable global localButton el valor
         *  
         *  del Content del Button pulsado
         */
        private void btn_ClickedAzar(object sender, RoutedEventArgs e)
        {
            letraButton = ((Button)sender).Content.ToString();
        }

    }
}
