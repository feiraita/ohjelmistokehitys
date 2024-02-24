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
        }

        public class Kategoria
        {
            public string nimi { get; set; }
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
            catch (Exception ex)
            {
            }
        }

        private void kategoriatDropdown_SelectionChanged(object sender, EventArgs e)
        {
        }
    }
}
