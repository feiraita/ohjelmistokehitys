using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rahatraiteille.MVVM.Classes
{
    internal class Kategoria
    {
        public string nimi { get; set; }

        public Kategoria(string nimi)
        {
            this.nimi = nimi;
        }
    }
}
