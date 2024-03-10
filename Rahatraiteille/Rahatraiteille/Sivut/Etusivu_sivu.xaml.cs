using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Rahatraiteille.Luokat;
using LiveCharts.Configurations;
using System.Transactions;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Rahatraiteille.Sivut
{
    public partial class Etusivu_sivu : Page, INotifyPropertyChanged
    {
        private double _lastLecture;
        private double _trend;

        List<Kategoria> kategorialista = new List<Kategoria>();
        List<Kirjaus> kirjauslista = new List<Kirjaus>();

        //public SeriesCollection Yhteenveto { get; set; } = new SeriesCollection();

        //List<double> yhteenvetoLista = new List<double>();

        public Etusivu_sivu()
        {

            InitializeComponent();

            LastHourSeries = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0),
                        new ObservableValue(0)
                    }
                }
            };

            Task.Run(() =>
            {
                while (true)
                {
                    /*foreach (var kirjaus in kirjauslista)
                    {
                        yhteenvetoLista.Add(kirjaus.euro);
                    }*/

                    Thread.Sleep(2000);
                    int count = Tallentaja_kategoria.LataaKategoriat().Count;
                    double summa = kirjauslista.Sum(kirjauslista => kirjauslista.euro);

                    _trend = (count);

                    //_yhteenveto = double.Join(", ", yhteenvetoLista);

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        double _summa = 0;
                        foreach (var kirjaus in kirjauslista)
                        {
                            _summa = _summa + kirjaus.euro;
                        }

                        LastHourSeries[0].Values.Add(new ObservableValue(_trend));
                        LastHourSeries[0].Values.RemoveAt(0);
                        SetLecture();

                        ListaMäärä.Text = count.ToString();
                        Lista.Text = count.ToString();
                        Aika2.Text = DateTime.Now.ToString("yyyy - MM - dd");
                        Summa.Text = _summa.ToString();
                        //_yhteenveto = string.Join(", ", yhteenvetoLista);
                    });
                }
            });

            DataContext = this;

            kategorialista = Tallentaja_kategoria.LataaKategoriat();
            kirjauslista = Tallentaja_kirjaus.LataaKirjaukset();


        }

        public SeriesCollection LastHourSeries { get; set; }

        public double LastLecture
        {
            get { return _lastLecture; }
            set
            {
                _lastLecture = value;
                OnPropertyChanged("LastLecture");
            }
        }

        private void SetLecture()
        {
            var target = ((ChartValues<ObservableValue>)LastHourSeries[0].Values).Last().Value;
            var step = (target - _lastLecture) / 4;

            Task.Run(() =>
            {
                for (var i = 0; i < 4; i++)
                {
                    Thread.Sleep(100);
                    LastLecture += step;
                }
                LastLecture = target;
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }

        private void UpdateOnclick(object sender, RoutedEventArgs e)
        {
            TimePowerChart.Update(true);

            kirjauslista = Tallentaja_kirjaus.LataaKirjaukset();
            double _summa = 0;
            foreach (var kirjaus in kirjauslista)
            {
                _summa = _summa + kirjaus.euro;
            }
            Summa.Text = _summa.ToString();
        }
    }
}
