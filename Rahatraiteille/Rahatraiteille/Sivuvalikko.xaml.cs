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

namespace Rahatraiteille
{
    /// <summary>
    /// Interaction logic for Sivuv.xaml
    /// </summary>
    public partial class Sivuvalikko : Page
    {
        public Sivuvalikko()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LisaaKategoria_sivu objKategoria = new LisaaKategoria_sivu();
            objKategoria.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LisaaKirjaus_sivu objKirjaus = new LisaaKirjaus_sivu();
            objKirjaus.Show();
        }
    }
}
