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
using System.Windows.Threading;
using Rahatraiteille.Sivut;

namespace Rahatraiteille
{
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            Ikkuna();
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
        private async void dtTicker(object sender, EventArgs e)
        {
            increment++;

            TimerLable.Content = increment.ToString();

            if (increment == 7)
            {
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
