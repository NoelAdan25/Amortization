using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amortizaciones.Logic
{
    class CreditoReport: ICreditoReport
    {
        private readonly Credito credito;
        public CreditoReport(Credito credito)
        {
            this.credito = credito;
        }
        public void MakeReport(out DataTable report)
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Period", typeof(float));
                data.Columns.Add("Interes Amount", typeof(String));
                data.Columns.Add("Amortization", typeof(String));
                data.Columns.Add("Amount", typeof(String));
                data.Columns.Add("Capital", typeof(String));
                foreach (float[] amounts in this.credito.amountDescription)
                {
                    data.Rows.Add(amounts[0], amounts[1].ToString("C2", CultureInfo.CurrentCulture), 
                        amounts[2].ToString("C2", CultureInfo.CurrentCulture), amounts[3].ToString("C2", CultureInfo.CurrentCulture), 
                        amounts[4].ToString("C2", CultureInfo.CurrentCulture));
                }
                report = data;
            }
            catch(Exception ex)
            {
                throw new CException("Indexing Error Report", ex);
            }
        }
    }
}
