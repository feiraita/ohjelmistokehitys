using System;
using System.Collections;
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
using System.Windows.Threading;
using Newtonsoft.Json;
using Rahatraiteille.Luokat;
using Rahatraiteille.Sivut;
using System.Text.Json;
using System.IO;

namespace Rahatraiteille
{
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        List<string> _vinkit = new List<string>();
        static Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            Ikkuna();
            LoadVinkitFromJson();
        }

        private void Ikkuna()
        {
            if (Tab1.IsEnabled == true)
            {
                F1.Content = new Etusivu_sivu();
            }
            if (Tab2.IsEnabled == true)
            {
                F2.Content = new LisaaKirjaus_sivu();
            }
            if (Tab3.IsEnabled == true)
            {
                F3.Content = new LisaaKategoria_sivu();
            }
            if (Tab4.IsEnabled == true)
            {
                F4.Content = new Tarkastele_sivu();
            } 
        }
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await Task.Delay(1);
            dt.Stop();
            Application.Current.Shutdown();
        }

        internal void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private int increment = 0;

        private void LoadVinkitFromJson()
        {
            try
            {
                string json = File.ReadAllText("Vinkit.json");
                List<Vinkki> vinkit = JsonConvert.DeserializeObject<List<Vinkki>>(json);

                foreach (var vinkki in vinkit)
                {
                    _vinkit.Add(vinkki.vinkki);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        private async void dtTicker(object sender, EventArgs e)
        {
            increment++;

            if (increment == 5)
            {
                int index = rnd.Next(_vinkit.Count);
                popupTextBlock.Text = _vinkit[index];
                Popup1.IsOpen = true;
                increment = 0;
            }

            if (increment == 1)
            {
                await Task.Delay(3500);
                Popup1.IsOpen = false;
                Popup1.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Fade;
            }
        }
    }
}
