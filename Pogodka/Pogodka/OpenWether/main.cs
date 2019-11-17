using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pogodka.OpenWether
{
    class main
    {
        private double temp;
        public double Temp
        {
            get {
                return temp;
            }
            set {
                temp = value;
            }
        }
        private double pressure;
        public double Pressure
        {
            get {
                return pressure;
            }
            set {
                pressure = value / 1.3332239;
            }
        }
        public double humidity;

        private double temp_min;
        public double Temp_min
        {
            get
            {
                return temp_min;
            }
            set
            {
                temp_min = value;
            }
        }

        private double temp_max;
        public double Temp_max
        {
            get
            {
                return temp_max;
            }
            set
            {
                temp_max = value;
            }
        }

    }
}
