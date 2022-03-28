using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortizaciones.Logic
{
    class Credito : ICreditoAction
    {
        private int period;
        private float amount;
        private float capitalAmount;
        public readonly List<float[]> amountDescription = new List<float[]>();
        public Credito(int period, float amount, List<float[]> dataLoaded)
        {
            this.Period = period;
            this.Amount = amount;
            this.capitalAmount = (amount / period);
            this.Interes = new Interes(amount, dataLoaded);
        }
        public float CapitalAmount { get => capitalAmount; private set => capitalAmount = value; }
        public float Amount { get => amount; private set => amount = value; }
        internal Interes Interes { get; private set; }
        public int Period { get => period; private set => period = value; }
        public void CalculateAmount()
        {
            try
            {
                // Set all Amounts
                float amountResult = this.amount;
                for (int x = 0; x <= this.period; x++)
                {
                    if(x == 0)
                    {
                        float[] amounts = { x, 0, 0, 0, amountResult };
                        this.amountDescription.Add(amounts);
                    }
                    else
                    {
                        float inPerio = amountResult * (this.Interes.Rate / 100f);
                        amountResult -= this.capitalAmount;
                        float[] amounts = { x, inPerio, this.capitalAmount, this.capitalAmount + inPerio, amountResult };
                        this.amountDescription.Add(amounts);
                    }
                }
            }catch(Exception ex)
            {
                throw new CException("Error in calculating amounts", ex);
            }
        }
    }
}
