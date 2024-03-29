﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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


        //hakee ja asettaa muutuujat--------------------------------------------
        internal class Sisältö
        {
            public SolidColorBrush kategoriaVari { get; set; }
            public string menoNimi { get; set; }
            public string menoEuro { get; set; }
            public string menoPv { get; set; }
            public string menoKategoria { get; set; }
        }
        //-----------------------------------------------------------------

        //Ladataan json tiedostosta kategoriat-----------------------------
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
        //-----------------------------------------------------------------

        //itse päivittäjä, itemcontrol lista elementti luonti ja sen asetus------------
        public void PaivitaLista()
        {
            List<Sisältö> items = new List<Sisältö>();

            foreach (var kirjaus in kirjauslista.TakeLast(10).Reverse())
            {
                items.Add(new Sisältö()
                {
                    menoNimi = kirjaus.nimi,
                    menoEuro = kirjaus.euro + " €",
                    menoKategoria = kirjaus.kategoria,
                    menoPv = kirjaus.pvm
                });
            }

            nimiTextBox.Text = string.Empty;
            kategoriatDropdown.Text = string.Empty;
            euroTextBox.Text = string.Empty;
            datePicker.Text = string.Empty;

            ICname.ItemsSource = items;
        }
        //-----------------------------------------------------------------

        //lisätään tieto json tiedostoon tietyssä formaatissa--------------
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
                MessageBox.Show("Täytä kentät oikein.",
                    "Kirjaus error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Tallentaja_kirjaus.TallennaKirjaukset(kirjauslista);
            PaivitaLista();
        }
        //-----------------------------------------------------------------

        //poistetaan nimen mukaan json elementti tiedostosta/listasta------
        private void Poista_Click(object sender, RoutedEventArgs e)
        {
            string name = string.Empty;
            string date = string.Empty;

            if (!string.IsNullOrEmpty(poistaTextBox.Text)) name = poistaTextBox.Text;
            if (!string.IsNullOrEmpty(poistaDatePicker.Text)) date = poistaDatePicker.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(date))
            {
                string Name = char.ToUpper(name.First()) + name.Substring(1).ToLower();
                var poistettava = kirjauslista.Find(item => (item.nimi == Name) && (item.pvm == date));

                if (poistettava != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Haluatko varmasti poistaa {date} {Name} -kirjauksen?",
                    "Kirjauksen postaminen", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes) kirjauslista.Remove(poistettava);
                }

                else
                {
                    MessageBox.Show($"{Name} nimistä kirjausta ei löytynyt.\nTarkista, että kirjoitit nimen oikein.",
                        "Kirjauksen poistaminen error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                PaivitaLista();
                Tallentaja_kirjaus.TallennaKirjaukset(kirjauslista);
                poistaTextBox.Text = "";
            }
        }//-------------------------------------------------------------------------

        //tekstilaatikon muuttuessa lable:t katoaa-----------------------------------------------
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (nimiTextBox.Text != "") nimiPlaceholder.Visibility = Visibility.Hidden;
            else nimiPlaceholder.Visibility = Visibility.Visible;

            if (euroTextBox.Text != "") euroPlaceholder.Visibility = Visibility.Hidden;
            else euroPlaceholder.Visibility = Visibility.Visible;

            if (poistaTextBox.Text != "") poistaPlaceholder.Visibility = Visibility.Hidden;
            else poistaPlaceholder.Visibility = Visibility.Visible;
        }
        //---------------------------------------------------------------------------------------
    }
}