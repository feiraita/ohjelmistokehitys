using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rahatraiteille.Luokat
{
    internal class Kirjaus
    {
        public string nimi { get; set; }
        public double euro { get; set; }

        public Kirjaus(string nimi, double euro)
        {
            this.nimi = nimi;
            this.euro = euro;
        }
    }
}
