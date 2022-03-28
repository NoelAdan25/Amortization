using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortizaciones.Logic
{
    interface IAnalizerFile
    {
        bool IsValid();
        void LoadData(out List<float[]> customRate);
    }
}
