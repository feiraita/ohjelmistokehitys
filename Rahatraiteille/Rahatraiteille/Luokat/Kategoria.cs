using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rahatraiteille.Luokat
{
    internal class Kategoria
    {
        public string nimi { get; set; }
        public string vari { get; set; }

        public Kategoria(string nimi, string vari)
        {
            this.nimi = nimi;
            this.vari = vari;
        }
    }
}
