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
using static Rahatraiteille.Tarkastele_sivu;

namespace Rahatraiteille
{
    /// <summary>
    /// Interaction logic for Tarkastele_sivu.xaml
    /// </summary>
    public partial class Tarkastele_sivu : Window
    {
        List<Kirjaus> kirjauslista = new List<Kirjaus>();
        public Tarkastele_sivu()
        {
            InitializeComponent();
            kirjauslista = Tallentaja_kirjaus.LataaKirjaukset();
            PaivitaLista();
        }

        internal class Sisältö
        {
            public SolidColorBrush kategoriaVari { get; set; }
            public string menoNimi { get; set; }
            public string menoEuro { get; set; }
            public string menoPv { get; set; }
            public string menoKategoria { get; set; }
        }

        public void PaivitaLista()
        {
            List<Sisältö> items = new List<Sisältö>();

            foreach (var kirjaus in kirjauslista.TakeLast(10).Reverse())
            {
                items.Add(new Sisältö() { menoNimi = kirjaus.nimi, menoEuro = kirjaus.euro + " €", menoKategoria = kirjaus.kategoria/*FindKategoriaColor(kirjaus.kategoria.ToString())*/, menoPv = kirjaus.pvm });
            }

            ICname.ItemsSource = items;
        }
    }
}
