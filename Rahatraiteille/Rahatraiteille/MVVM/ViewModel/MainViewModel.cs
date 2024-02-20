using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rahatraiteille.MVVM.ViewModel
{
    internal class MainViewModel : BasedViewModel
    {
        public BasedViewModel CurrentViewModel { get; }

        public MainViewModel() 
        {
            CurrentViewModel = new EtusivuViewModel();
        }
    }
}
