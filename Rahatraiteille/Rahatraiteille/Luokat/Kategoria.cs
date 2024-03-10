using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rahatraiteille.Sivut;

namespace Rahatraiteille.Luokat
{
    internal class Kategoria
    {
        //hakee ja asettaa muutuujat--------------------------------------------s
        public string nimi { get; set; }
        public string vari { get; set; }

        public Kategoria(string nimi, string vari)
        {
            this.nimi = nimi;
            this.vari = vari;
        }
    }
}
