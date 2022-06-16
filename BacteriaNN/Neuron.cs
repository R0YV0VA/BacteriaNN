using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacteriaNN
{
    class Neuron
    {
        private static Random rnd = new Random();
        public double Impulse { get; set; } = 0;
        public double Weight { get; set; } = rnd.NextDouble();

    }
}
