using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortizaciones.Logic
{
    class AnalizerFile:IAnalizerFile
    {
        private readonly String[] headers = new String[] { "minAmount", "rate", "maxAmount" };
        private readonly String pathFile;
        public AnalizerFile(String pathFile)
        {
            this.pathFile = pathFile;
        }
        public bool IsValid()
        {
            bool flag = false;
            try
            {
                TextFieldParser parser = new TextFieldParser(this.pathFile)
                {
                    TextFieldType = FieldType.Delimited
                };
                parser.SetDelimiters(",");
                String[] fields = parser.ReadFields();
                flag = this.headers.SequenceEqual(fields);
            }
            catch (Exception ex)
            {
                throw new CException("Error on Evaluating File", ex);
            }
            return flag;
        }
        public void LoadData(out List<float[]> customRate)
        {
            TextFieldParser parser = new TextFieldParser(this.pathFile)
            {
                TextFieldType = FieldType.Delimited
            };
            parser.SetDelimiters(",");
            parser.ReadLine();
            List<float[]> varValues = new List<float[]>();
            while (!parser.EndOfData)
            {
                String[] fields = parser.ReadFields();
                float[] values = new float[fields.Length];
                int valRunner = 0;
                foreach(String dat in fields)
                {
                    values[valRunner] = float.Parse(dat);
                    valRunner += 1;
                }
                varValues.Add(values);
            }
            customRate = varValues;
        }
    }
}
