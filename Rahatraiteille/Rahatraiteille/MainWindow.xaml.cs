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

namespace Rahatraiteille
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> kategoriat = [];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kategoriat.Add(textBox.Text);
            textBlock.Text = string.Join("\n", kategoriat);
            textBox.Clear();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox.Text != "")
            {
                textBoxPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                textBoxPlaceholder.Visibility = Visibility.Visible;
            }
        }
    } 
}