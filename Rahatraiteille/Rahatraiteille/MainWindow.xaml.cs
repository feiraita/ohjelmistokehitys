using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Rahatraiteille
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> kategoriat = [];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kategoriat.Add(textBox.Text);
            textBlock.Text = string.Join("\n", kategoriat);
            textBox.Clear();
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

        //Popup ikkuna -----------------------------------------------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
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
        //--------------------------------------------------------------------------------------------
    }
}