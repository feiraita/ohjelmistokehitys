using System;
using System.Collections.Generic;
using System.IO;
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
using Rahatraiteille.Luokat;

namespace Rahatraiteille.Sivut
{
    /// <summary>
    /// Interaction logic for LisaaKirjaus_sivu.xaml
    /// </summary>
    public partial class LisaaKirjaus_sivu : Page
    {
        List<Kirjaus> kirjauslista = new List<Kirjaus>();
        public LisaaKirjaus_sivu()
        {
            InitializeComponent();
        }
  

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = string.Empty;
            double cost;

            if (!string.IsNullOrEmpty(nimiTextBox.Text)) name = nimiTextBox.Text;

            double.TryParse(euroTextBox.Text, out cost);

            if (!string.IsNullOrEmpty(name) && cost > 0)
            {
                var newKirjaus = new Kirjaus(name, cost);
                kirjauslista.Add(newKirjaus);
            }

            nimiTextBox.Text = "";
            euroTextBox.Text = "";

            var stringgi = "";
            foreach (var kirjaus in kirjauslista)
                stringgi += $"{kirjaus.nimi} [{kirjaus.euro} €]\n";

            textBlock.Text = stringgi;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nimiTextBox.Text != "")
            {
                nimiPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                nimiPlaceholder.Visibility = Visibility.Visible;
            }

            if (euroTextBox.Text != "")
            {
                euroPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                euroPlaceholder.Visibility = Visibility.Visible;
            }
        }
    }
}
