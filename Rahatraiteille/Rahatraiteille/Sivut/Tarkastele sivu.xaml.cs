using LiveCharts.Wpf;
using LiveCharts;
using Newtonsoft.Json;
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
using LiveCharts.Defaults;
using System.IO;

namespace Rahatraiteille.Sivut
{
    public partial class MainWindow : Tarkastele_sivu
    {
        public SeriesCollection ChartValues { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Add_PieChart_Click(object sender, RoutedEventArgs e)
        {
            string jsonData = File.ReadAllText("kirjaus.json");
            List<DataPoint> dataPoints = JsonConvert.DeserializeObject<List<DataPoint>>(jsonData);

            ChartValues = new SeriesCollection();
            foreach (var dataPoint in dataPoints)
            {
                ChartValues.Add(new PieSeries { Title = "raha" + dataPoint.ID, Values = new ChartValues<double> { dataPoint.Value } });
            }
        }

        private class DataPoint
        {
            public int ID { get; set; }
            public double Value { get; set; }
        }
    }
}
}
