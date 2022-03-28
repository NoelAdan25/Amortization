using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortizaciones.Logic
{
    class Interes
    {
        private float rate;
        private List<float[]> customRate = new List<float[]>();
        public Interes(float amount, List<float[]> customRate)
        {
            // Set the rate interes
            this.customRate = customRate;
            bool valCon = false;
            foreach(float[] rates in customRate)
            {
                if(rates[0] <= amount && rates[2] >= amount)
                {
                    this.rate = rates[1];
                    valCon = true;
                    break;
                }
            }
            if (!valCon)
            {
                throw new CException("Error in amounts and rates", new ArgumentException());
            }
        }
        public float Rate { get => rate; set => rate = value; }
        public List<float[]> CustomRate { get => customRate; set => customRate = value; }
    }
}
