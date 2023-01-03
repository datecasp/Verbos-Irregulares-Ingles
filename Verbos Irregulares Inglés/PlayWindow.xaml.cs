﻿using System;
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
    public partial class PlayWindow : Window
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
        public char[] letrasAzarChar;

        public int acierto = 0;
        public int numLetras = 0;
        int index = 0;

        //public string[] palabraTapada;

        public PlayWindow()
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
            letrasAzarChar = completaArrayLetrasAzar(palabraGapChar);
            //palabraTapada = new string[palabraArrayChar.Length];

            txtPlayGameCompleta.Text = $"The complete word in {getTiempoVerbal(atrRandomCompleta.posicion)} is {palabraCompleta}";
            txtPlayGameGap.Text = $"The gapped word in {getTiempoVerbal(atrRandomGap.posicion)} is...";
            
            
            pintaBtnGrids(creaGridPalabraGap(palabraGapChar), palabraGapButtons, palabraGapChar);


            //Revisar este método. Crea Grid y arrayLetrasAzar
            pintaBtnGrids(creaGridLetrasAzar(letrasAzarChar), letrasAzarButtons, letrasAzarChar);
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

        private char[] completaArrayLetrasAzar(char[] arrayLetrasAzarInicial)
        {
            Random rd = new Random();
            int numLetrasFinal = 0;

            if (arrayLetrasAzarInicial.Length <= 2)
            {
                numLetrasFinal = 5;
            }
            else if (2 < arrayLetrasAzarInicial.Length && arrayLetrasAzarInicial.Length <= 4)
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
                if (i < arrayLetrasAzarInicial.Length)
                {
                    result[i] = arrayLetrasAzarInicial[i];
                }
                else
                {
                    result[i] = Data.Datos.abecedario[rd.Next(Data.Datos.abecedario.Length)];
                }
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
        private void pintaBtnGrids(Grid gridLetters, Button[] charButtons,char[] arrayChars)
        {

            if (acierto == 0)
            {
                for (int i = arrayChars.GetLowerBound(0); i <= arrayChars.GetUpperBound(0); i++)
                {
                    if (Char.IsLetter(arrayChars[i]))
                    {
                        charButtons = new Button[arrayChars.Length];

                        gridLetters.ColumnDefinitions.Add(new ColumnDefinition());
                        charButtons[i] = this.Resources["btnPlayLetter"] as Button;
                        charButtons[i].Content = arrayChars[i];
                        Grid.SetColumn(charButtons[i], i);
                        gridLetters.Children.Add(charButtons[i]);
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
