using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacteriaNN
{
    class Layer
    {
        public Neuron[] neurons;
        public int count;
        public Layer(int c)
        {
            count = c;
            neurons = new Neuron[count];
            for (int i = 0; i < count; i++)
            {
                neurons[i] = new Neuron();
            }
        }

        public double weight_sum = 0;

        public void SetNeuroImpulse(int c, double i)
        {
            neurons[c].Impulse = i;
        }
        public void SetNeuroWeigh(int c, double w)
        {
            neurons[c].Weight = w;
        }
        public double GetNeuroWeigh(int c)
        {
            return neurons[c].Weight;
        }
        public double GetNeuroImpulse(int c)
        {
            return neurons[c].Impulse;
        }

        public void Summing()
        {
            weight_sum = 0;
            for (int i = 0; i < count; i++)
            {
                weight_sum += neurons[i].Weight * neurons[i].Impulse;
            }
        }
        public double Sigmoid()
        {
            Summing();
            //return Math.Max(0, weight_sum);
            return 1 / (1 + Convert.ToDouble(Math.Exp(-weight_sum)));
            //return (2 / (1 + Convert.ToDouble(Math.Pow(Math.E, -2*weight_sum)))) - 1;
        }


    }
}
