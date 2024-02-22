using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace Rahatraiteille.Chart
{
    class Person
    {
        string Name { get; set; }
        int Height {  get; set; }
        public Person(string name, int height)
        {
            Name = name;
            Height = height;
        }
    }
}
