﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rahatraiteille.Luokat
{
    internal class Vinkki
    {
        //hakee ja asettaa muutuujat--------------------------------------------
        public string vinkki { get; set; }

        public Vinkki(string vinkki)
        {
            this.vinkki = vinkki;
        }
    }
}
