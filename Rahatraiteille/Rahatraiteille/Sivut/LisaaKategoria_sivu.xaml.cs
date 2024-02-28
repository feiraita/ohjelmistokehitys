using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
using Rahatraiteille.Luokat;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rahatraiteille.Sivut
{
    /// <summary>
    /// Interaction logic for LisaaKategoria_sivu.xaml
    /// </summary>
    public partial class LisaaKategoria_sivu : Page
    {
        List<Kategoria> kategorialista = new List<Kategoria>();

        public LisaaKategoria_sivu()
        {
            InitializeComponent();
            kategorialista = Tallentaja_kategoria.LataaKategoriat();
            PaivitaLista();
        }

        public void PaivitaLista()
        {
            var stringgi = "";
            foreach (var kategoria in kategorialista)
                stringgi += $"{kategoria.nimi} - {kategoria.vari}\n";

            textBlock.Text = stringgi;

            nimiTextBox.Text = string.Empty;
            variTextBox.Text = string.Empty;
        }

        private void Lisaa_Click(object sender, RoutedEventArgs e)
        {
            string name = string.Empty;
            string color = string.Empty;

            if (!string.IsNullOrEmpty(nimiTextBox.Text)) name = nimiTextBox.Text;
            if (!string.IsNullOrEmpty(variTextBox.Text)) color = variTextBox.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(color))
            {
                string Name = char.ToUpper(name.First()) + name.Substring(1).ToLower();
                string Color = char.ToUpper(color.First()) + color.Substring(1).ToLower();

                var newKategoria = new Kategoria(Name, Color);
                kategorialista.Add(newKategoria);
            }

            else
            {
                MessageBox.Show("Täytä kentät oikein.", 
                    "Kirjaus error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
            Tallentaja_kategoria.TallennaKategoriat(kategorialista);
            PaivitaLista();
            KategorianVari();
        }
        
        private void Poista_Click(object sender, RoutedEventArgs e)
        {
            string name = string.Empty;

            if (!string.IsNullOrEmpty(poistaTextBox.Text)) name = poistaTextBox.Text;

            if (!string.IsNullOrEmpty(name))
            {
                string Name = char.ToUpper(name.First()) + name.Substring(1).ToLower();
                var poistettava = kategorialista.FirstOrDefault(item => item.nimi == Name);

                if (poistettava != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Haluatko varmasti poistaa {Name} -kategorian?",
                    "Kategorian postaminen", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes) kategorialista.Remove(poistettava);
                }

                else
                {
                    MessageBox.Show($"{Name} nimistä kategoriaa ei löytynyt.\nTarkista, että kirjoitit nimen oikein.", 
                        "Kategoria error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            PaivitaLista();
            Tallentaja_kategoria.TallennaKategoriat(kategorialista);
            poistaTextBox.Text = "";
        }

        public void KategorianVari()
        {
            string before = variTextBox.Text;
            string after = char.ToUpper(before.First()) + before.Substring(1).ToLower();

            SolidColorBrush myBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(after);
            rectangle.Fill = myBrush;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nimiTextBox.Text != "") nimiPlaceholder.Visibility = Visibility.Hidden;
            else nimiPlaceholder.Visibility = Visibility.Visible;

            if (variTextBox.Text != "") variPlaceholder.Visibility = Visibility.Hidden;
            else variPlaceholder.Visibility = Visibility.Visible;

            if (poistaTextBox.Text != "") poistaPlaceholder.Visibility = Visibility.Hidden;
            else poistaPlaceholder.Visibility = Visibility.Visible;
        }
    }
}


/* try
                {
                    string Name = char.ToUpper(name.First()) + name.Substring(1).ToLower();

                    var poistettava = kategorialista.First(item => name == Name);
                    kategorialista.Remove(poistettava);
                }
                catch (Exception ex) { 
                    textBlock.Text = ex.Message;
                }
*/
/*
var list = new List<string> { "Red", "Blue", "Green" };

var rnd = new Random();
int index = rnd.Next(list.Count);
textBlock2.Text = list[index];

SolidColorBrush myBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(list[index]);

variNappi.Background = myBrush;
*/