﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rahatraiteille.MVVM.ViewModel
{
    internal class EtusivuViewModel : BasedViewModel
    {
        public ICommand NavigateAccountCommand { get; }
    }
}
