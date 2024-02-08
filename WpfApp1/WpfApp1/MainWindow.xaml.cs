using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void AvaaIkkuna(object sender, RoutedEventArgs e)
        {
            Etusivu objEtusivu = new Etusivu();
            objEtusivu.Show();
        }



        private void AvaaIkkuna1(object sender, RoutedEventArgs e)
        {
            Sivuvalikko objSivuvalikko = new Sivuvalikko();
            objSivuvalikko.Show();
        }
    }
}