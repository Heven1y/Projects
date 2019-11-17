using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pogodka.OpenWether
{
    class OpenWether
    {
        public coord coord;
        public weather[] weather;
        [JsonProperty("base")]
        public string Base;
        public main main;

        public double visibility, dt, cod;
        public wind wind;
        public Clouds clouds;
        public sys sys;
        public int id;
        public string name;
    }
}
