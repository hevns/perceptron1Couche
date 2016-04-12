using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace perceptron1Couche
{
    class simplePerceptron
    {
        private List<double> weight;
        public double Out { get; set; }
        public simplePerceptron(int nbEntry)
        {
            Random rnd = new Random();
            weight = new List<double>();
            for (int i = 0; i < nbEntry; ++i)
                weight.Add(rnd.NextDouble());
        }
        public int getNbENtry()
        {
            return weight.Count;
        }
        public int calculOut(params double[] entries)
        {
            if (entries.Length != weight.Count)
                return -1;
            Out = 0;
            for (int i = 0; i < entries.Length; ++i)
                Out += weight[i] * entries[i];
            return (Out>0)?1:0;
        }
        public double getWeightEntry(int i)
        {
            if (i > weight.Count)
                return -1;
            else return weight[i];
        }
        public void addWeightEntry(int i, double w)
        {
            if (i > weight.Count)
                return;
            weight[i] += w;
        }
        
    }
}
