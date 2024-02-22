using Syncfusion.UI.Xaml.Charts;
using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Rahatraiteille.Sivut;
using Rahatraiteille.Chart;

namespace Rahatraiteille.Sivut
{
    public partial class Etusivu_sivu : Page
    {
        public Etusivu_sivu()
        {
            InitializeComponent();
        }
        DoughnutSeries series = new DoughnutSeries()
        {

            ItemsSource = new ViewModel().Data,

            XBindingPath = "Category",

            YBindingPath = "Percentage"
        };

       // chart.Series.Add(series);
    }
}
