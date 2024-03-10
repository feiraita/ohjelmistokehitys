using Newtonsoft.Json;
using Rahatraiteille.Luokat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json.Linq;
using static Rahatraiteille.Tarkastele_sivu;
using System.Collections;
using System.Globalization;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Rahatraiteille
{
    public partial class Tarkastele_sivu : Page
    {
        List<Kirjaus> kirjauslista = new List<Kirjaus>();
        List<Sisältö> items = new List<Sisältö>();
        Regex regex = new Regex("[^0-9.]");

        public Tarkastele_sivu()
        {
            InitializeComponent();
            kirjauslista = Tallentaja_kirjaus.LataaKirjaukset(); //Lataa jsonista kirjaukset tallentaja_kirjaus classin kautta
            LoadKategoriatFromJson(); //Lataa kategoriat jsonista ohjelman avautuessa

            // Nimen etsintä------------------------------------------------------------------------
            Nimi.TextChanged += (sender, e) =>
            {
                string searchText = Nimi.Text.ToLower();
                List<Sisältö> filteredItems = items.Where(item => item.menoNimi.ToLower().Contains(searchText)).ToList();

                ICname.ItemsSource = null;
                ICname.ItemsSource = filteredItems;
            };
            //--------------------------------------------------------------------------------------

            // Kategorian kautta etsiminen----------------------------------------------------------
            Kansio.SelectionChanged += (sender, e) =>
            {
                string selectedCategory = Kansio.SelectedItem.ToString();
                List<Sisältö> filteredItems = items.Where(item => item.menoKategoria.ToLower() == selectedCategory.ToLower()).ToList();

                ICname.ItemsSource = null;
                ICname.ItemsSource = filteredItems;
            };
            //-------------------------------------------------------------------------------------

            //Etsitään ajan kautta
            Aika.SelectedDateChanged += (sender, e) =>
            {
                DateTime? selectedDate = Aika.SelectedDate;

                if (selectedDate != null)
                {
                    string selectedDateAsString = selectedDate.Value.ToString("dd/MM/yyyy");

                    List<Sisältö> filteredItems = items.Where(item => item.menoPv == selectedDateAsString).ToList();

                    ICname.ItemsSource = null;

                    ICname.ItemsSource = filteredItems;
                }
                else { ICname.ItemsSource = items; }
            };//------------------------------------------------------------------------------
        }

        //Ikkunan avautuessa päivittyy-------------------------------------------------
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PaivitaLista();
        }
        //------------------------------------------------------------------------------

        //hakee ja asettaa muuttujat-----------------------------------------------------
        internal class Sisältö
        {
            public SolidColorBrush kategoriaVari { get; set; }
            public string menoNimi { get; set; }
            public string menoEuro { get; set; }
            public string menoPv { get; set; }
            public string menoKategoria { get; set; }
        }
        //------------------------------------------------------------------------------

        //itse päivittäjä, itemcontrol lista elementti luonti ja sen asetus------------
        public void PaivitaLista()
        {
            foreach (var kirjaus in kirjauslista)
            {
                items.Add(new Sisältö()
                {
                    menoNimi = kirjaus.nimi,
                    menoEuro = kirjaus.euro.ToString(),
                    menoKategoria = kirjaus.kategoria,
                    menoPv = kirjaus.pvm
                });
            }

            ICname.ItemsSource = items;
        }
        //------------------------------------------------------------------------------

        //Ladataan kategoriat json tiedostosta-----------------------------------------
        private void LoadKategoriatFromJson()
        {
            try
            {
                string json = File.ReadAllText("kategoriat.json");
                List<Kategoria> kategoriat = JsonConvert.DeserializeObject<List<Kategoria>>(json);

                foreach (var kategoria in kategoriat)
                {
                    Console.WriteLine(kategoria.nimi);
                    Kansio.Items.Add(kategoria.nimi);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        //------------------------------------------------------------------------------

        //Tutkitaan napeilla rahan kautta järjestyksessä---------------------------------------
        private void RahaY_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in items)
            {
                item.menoEuro = regex.Replace(item.menoEuro, "");
            }

            items.Sort((x, y) => {
                double xEuro, yEuro;
                double.TryParse(x.menoEuro, NumberStyles.Float, CultureInfo.InvariantCulture, out xEuro);
                double.TryParse(y.menoEuro, NumberStyles.Float, CultureInfo.InvariantCulture, out yEuro);

                return yEuro.CompareTo(xEuro);
            });

            ICname.ItemsSource = null;
            ICname.ItemsSource = items;
        }        //------------------------------------------------------------------------------

        //Tutkitaan napeilla rahan kautta järjestyksessä---------------------------------------
        private void RahaX_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in items)
            {
                item.menoEuro = regex.Replace(item.menoEuro, "");
            }

            items.Sort((x, y) => {
                double xEuro, yEuro;
                double.TryParse(x.menoEuro, NumberStyles.Float, CultureInfo.InvariantCulture, out xEuro);
                double.TryParse(y.menoEuro, NumberStyles.Float, CultureInfo.InvariantCulture, out yEuro);

                return xEuro.CompareTo(yEuro);
            });

            ICname.ItemsSource = null;
            ICname.ItemsSource = items;
        }        //------------------------------------------------------------------------------

        //tekstilaatikon muuttuessa lable:t katoaa-----------------------------------------------
        private void Nimi_TextChanged(object sender, EventArgs e)
        {
            if (Nimi.Text != "") nimiPlaceholder.Visibility = Visibility.Hidden;
            else nimiPlaceholder.Visibility = Visibility.Visible;
        }
        //-----------------------------------------------------------------------------------------
    }
}
