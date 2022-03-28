using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amortizaciones.Logic
{
    interface ICreditoReport
    {
        void MakeReport(out DataTable report);
    }
}
