﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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

namespace Rahatraiteille
{
    /// <summary>
    /// Interaction logic for Etusivu.xaml
    /// </summary>
    public partial class Etusivu : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        public Etusivu()
        {
            InitializeComponent();
        }
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await Task.Delay(1);
            dt.Stop();
            Application.Current.Shutdown();
            // < MenuItem Header = "Tällä sivulla voit kirjata menon, ja tarkastella muutamaa edellistä menoa." />
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            LisaaKirjaus_sivu mainWindow = new LisaaKirjaus_sivu();
            Visibility = Visibility.Hidden;
            mainWindow.Show();
            dt.Stop();
        }
    }
}
