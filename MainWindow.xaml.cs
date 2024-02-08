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

namespace IKKUNA
{
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void AvaaIkkuna(object sender, RoutedEventArgs e)
        {
            SecondWindow1 objSecondWindow1 = new SecondWindow1();
            this.Visibility = Visibility.Visible;
            objSecondWindow1.Show();
        }

        private void AvaaIkkuna1(object sender, RoutedEventArgs e)
        {
            Sivuvalikko objSivuvalikko = new Sivuvalikko();
            this.Visibility = Visibility.Visible;
            objSivuvalikko.Show();
        }
    }
}