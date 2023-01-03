using System;
using System.Collections;
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
using System.Windows.Shapes;
using Verbos_Irregulares_Inglés.Modelos;
using Verbos_Irregulares_Inglés.Servicios;
using Verbos_Irregulares_Inglés.Utilidades;

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

        public int acierto = 0;
        public int numLetras = 0;
        public string letraButton = "";

        //public string[] palabraTapada;

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
            grdPlayIntro.Visibility = Visibility.Hidden;
            grdPlayGame.Visibility = Visibility.Visible;
            btnPlay.Content = "Otra palabra";
            //Reset variables
            //txtLineas.Text = "";
            //Buscamos un verbo aleatorio entre los 29 de la lista
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
            //palabraTapada = new string[palabraArrayChar.Length];

            txtPlayGameCompleta.Text = $"The complete word in {getTiempoVerbal(atrRandomCompleta.posicion)} is {palabraCompleta}";
            txtPlayGameGap.Text = $"The gapped word in {getTiempoVerbal(atrRandomGap.posicion)} is...";
            
            
            pintaBtnGrids(creaGridPalabraGap(palabraGapChar), palabraGapButtons, palabraGapPistasChar, "pistas");
            pintaBtnGrids(creaGridLetrasAzar(letrasAzarChar), letrasAzarButtons, letrasAzarChar, "azar");
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

        private Grid creaGridPalabraGap(char[] palabraGapChar)
        {
            Grid grdPlayBtnLetters = new Grid();
            grdPlayBtnLetters.Margin = new Thickness(0, 175, 0, 0);
            grdPlayBtnLetters.VerticalAlignment = VerticalAlignment.Top;
            grdPlayBtnLetters.HorizontalAlignment = HorizontalAlignment.Center;
            grdPlayGame.Children.Add(grdPlayBtnLetters);
            if(grdPlayGame.Children.Count > 3)
            {
                grdPlayGame.Children[grdPlayGame.Children.Count - 2].Visibility = Visibility.Hidden;
            }
            grdPlayBtnLetters.Width = (palabraGapChar.Length + 1) * 55;
            return grdPlayBtnLetters;
        }

        /***
         * 
         *  private void pintaLetrasAzar(Grid grdPlayBtnLetters)
         *  
         *  Método que recibe el array de char con los caracteres de la palabra a acertar.
         *  
         *  En función del número de letras de la palabra, muestra 0 a varias como pista
         *  
         *  
         * 
         */
        private Grid creaGridLetrasAzar(char[] letrasArrayChar)
        {
            Grid grdLetrasAzar = new Grid();
            grdLetrasAzar.Margin = new Thickness(0, 0, 0, 50);
            grdLetrasAzar.VerticalAlignment = VerticalAlignment.Bottom;
            grdLetrasAzar.HorizontalAlignment = HorizontalAlignment.Center;
            grdPlayLetrasAzar.Children.Add(grdLetrasAzar);
            if (grdPlayLetrasAzar.Children.Count > 1)
            {
                grdPlayLetrasAzar.Children[grdPlayLetrasAzar.Children.Count - 2].Visibility = Visibility.Hidden;
            }
            grdLetrasAzar.Width = (letrasArrayChar.Length + 1) * 55;
            return grdLetrasAzar;
        }

        /***
         * 
         *  private void pintaBtnPalabraGap(Grid grdPlayBtnLetters)
         *  
         *  Método que recibe el Grid con las letras de la palabra a rellenar.
         *  
         *  A través del flag acierto, hace dos posibles tareas: 
         *  
         *  -Pintar un Button por cada letra de la palabra a rellenar
         *  
         *  -Pintar las letras de la palabra dentro de los botones correspondientes
         *  
         */
        private void pintaBtnGrids(Grid gridLetters, Button[] charButtons,char[] arrayChars, string flagTipoBtn)
        {

            if (acierto == 0)
            {
                for (int i = arrayChars.GetLowerBound(0); i <= arrayChars.GetUpperBound(0); i++)
                {
                    charButtons = new Button[arrayChars.Length];
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

                    if (Char.IsLetter(arrayChars[i]))
                    {
                       // numLetras++;
                    }
                    else if (Char.IsSeparator(arrayChars[i]))
                    {
                        //palabraTapada[i] = "   ";
                    }
                    else
                    {
                        //palabraTapada[i] = arrayChars[i].ToString();
                    }
                }
            }
            else
            {
                //txtLineas.Text = "";
                for (int i = arrayChars.GetLowerBound(0); i <= arrayChars.GetUpperBound(0); i++)
                {

                    //txtLineas.Text += palabraTapada[i].ToString();
                }

            }
        }

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

        private void chequeaPalabraGapButtons()
        {
            bool completa = true;
            bool bien = true;
            char[] respuesta = new char[palabraGapChar.Length];
            for (int i = 0; i < palabraGapChar.Length; i++)
            {
                /////REVISAR ESTO
                ///


                if (!Char.IsLetter((Char)(palabraGapButtons[i].Content)))
                {
                    completa = false;
                }
                else
                {
                    respuesta[i] = palabraGapButtons[i].Content;
                }
            }
            if (completa)
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

        private void btn_ClickedAzar(object sender, RoutedEventArgs e)
        {
            letraButton = ((Button)sender).Content.ToString();
        }

        private char[] randomCharArray(int numLetras, char[] letras)
        {
            Random rd = new Random();
            char[] result = new char[numLetras];
            for (int i = 0; i < numLetras; i++)
            {
                if (i > 0)
                {
                    do
                    {
                        result[i] = letras[rd.Next(letras.Length)];

                    } while (result[i] == result[i - 1]);
                }
            }

            return result;
        }

    }
}
