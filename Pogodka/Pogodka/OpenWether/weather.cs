using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pogodka.OpenWether
{
    class weather
    {
        public int id;
        public string main, description;
        public string icon;
        public Bitmap Icon
        {
            get{
                return new Bitmap(Image.FromFile($"icons/{icon}.png"));

            }
        }
    }
}
