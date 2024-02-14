using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Rahatraiteille
{
    /// <summary>
    /// Interaction logic for LisaaKategoria_sivu.xaml
    /// </summary>
    public partial class LisaaKategoria_sivu : Window
    {
        List<Kategoria> kategorialista = new List<Kategoria>();

        public LisaaKategoria_sivu()
        {
            InitializeComponent();
            textBlock.Text = Tallentaja_kategoria.testi();
            kategorialista = Tallentaja_kategoria.LataaKategoriat();
            PaivitaLista();
        }
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await Task.Delay(1);
            //dt.Stop();
            Application.Current.Shutdown();
        }
        

        // LÄHETÄ -nappi
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = string.Empty;

            if (!string.IsNullOrEmpty(textBox.Text)) name = textBox.Text;

            if (!string.IsNullOrEmpty(name))
            {
                var newKategoria = new Kategoria(name);
                kategorialista.Add(newKategoria);
            }

            PaivitaLista();
            Tallentaja_kategoria.TallennaKategoriat(kategorialista);
            textBox.Text = "";
        }
        public void PaivitaLista()
        {
            var stringgi = "";
            foreach (var kategoria in kategorialista)
                stringgi += $"{kategoria.nimi}\n";

            textBlock.Text = stringgi;
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
