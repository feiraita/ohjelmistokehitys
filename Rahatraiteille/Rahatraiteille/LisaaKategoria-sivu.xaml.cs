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

namespace Rahatraiteille
{
    /// <summary>
    /// Interaction logic for LisaaKategoria_sivu.xaml
    /// </summary>
    public partial class LisaaKategoria_sivu : Window
    {
        List<string> kategoriat = [];

        public LisaaKategoria_sivu()
        {
            InitializeComponent();
        }
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await Task.Delay(1);
            //dt.Stop();
            Application.Current.Shutdown();
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
