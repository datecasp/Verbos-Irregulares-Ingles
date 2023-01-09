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
using System.Windows.Shapes;

namespace Verbos_Irregulares_Inglés
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIntroTest_Click(object sender, RoutedEventArgs e)
        {
            TestWindow4 testWindow = new ();
            testWindow.Show();
        }

        private void btnIntroPlay_Click(object sender, RoutedEventArgs e)
        {
            FillGapsWindow playWindow = new ();
            playWindow.Show();
        }
    }
}
