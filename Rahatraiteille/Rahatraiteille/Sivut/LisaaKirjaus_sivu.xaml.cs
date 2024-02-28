using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using Rahatraiteille.Luokat;

namespace Rahatraiteille.Sivut
{
    public partial class LisaaKirjaus_sivu : Page
    {
        List<Kirjaus> kirjauslista = new List<Kirjaus>();
        
        public LisaaKirjaus_sivu()
        {
            InitializeComponent();
            LoadKategoriatFromJson();
            kirjauslista = Tallentaja_kirjaus.LataaKirjaukset();
            PaivitaLista();
        }

        public class Kategoria
        {
            public string nimi { get; set; }
        }

        private void Lisaa_Click(object sender, RoutedEventArgs e)
        {
            string name = string.Empty;
            string category = string.Empty;
            double cost;
            string date = string.Empty;

            if (!string.IsNullOrEmpty(nimiTextBox.Text)) name = nimiTextBox.Text;
            if (!string.IsNullOrEmpty(datePicker.Text)) date = datePicker.Text;
            if (!string.IsNullOrEmpty(kategoriatDropdown.Text)) category = kategoriatDropdown.Text;
            double.TryParse(euroTextBox.Text, out cost);

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(category) & !string.IsNullOrEmpty(date) && cost > 0)
            {
                string Name = char.ToUpper(name.First()) + name.Substring(1).ToLower();
                string Category = char.ToUpper(category.First()) + category.Substring(1).ToLower();

                var newKirjaus = new Kirjaus(Name, Category, cost, date);
                kirjauslista.Add(newKirjaus); 
            }
            else
            {
                MessageBox.Show("Täytä kentät oikein.", "Kirjaus error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Tallentaja_kirjaus.TallennaKirjaukset(kirjauslista);
            PaivitaLista(); 
        }

        public void PaivitaLista()
        {
            var stringgi = "";
            foreach (var kirjaus in kirjauslista.TakeLast(4).Reverse())
                stringgi += $"{kirjaus.nimi} [{kirjaus.euro} €] - [{kirjaus.kategoria}] {kirjaus.pvm}\n";

            textBlock.Text = stringgi;

            nimiTextBox.Text = string.Empty;
            kategoriatDropdown.Text = string.Empty;
            euroTextBox.Text = string.Empty;
            datePicker.Text = string.Empty;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
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

        private void LoadKategoriatFromJson()
        {
            try
            {
                string json = File.ReadAllText("kategoriat.json");
                List<Kategoria> kategoriat = JsonConvert.DeserializeObject<List<Kategoria>>(json);

                foreach (var kategoria in kategoriat)
                {
                    Console.WriteLine(kategoria.nimi);
                    kategoriatDropdown.Items.Add(kategoria.nimi);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
    }
}
