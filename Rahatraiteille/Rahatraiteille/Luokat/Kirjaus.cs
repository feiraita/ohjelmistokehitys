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
        public string kategoria { get; set; }
        public double euro { get; set; }
        public string pvm { get; set; }

        public Kirjaus(string nimi, string kategoria, double euro, string pvm)
        {
            this.nimi = nimi;
            this.kategoria = kategoria;
            this.euro = euro;
            this.pvm = pvm;
        }
    }
}
