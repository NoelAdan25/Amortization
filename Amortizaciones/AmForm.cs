using Amortizaciones.Logic;
using Amortizaciones.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amortizaciones
{
    public partial class AmForm : Form
    {
        public AmForm()
        {
            InitializeComponent();
            amount.Controls[0].Visible = false;
            amount.Controls[0].Enabled = false;
            calculateButton.Enabled = false;
            calculateButton.ForeColor = System.Drawing.Color.White;
        }
        private void SearchEvent(object sender, EventArgs e)
        {
            searchDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Office Files|*.csv;"
            };
            searchDialog.ShowDialog();
            fileData.Text = searchDialog.FileName;
            fileData.Enabled = (fileData.Text == String.Empty);
            calculateButton.Enabled = !fileData.Enabled;
            searchButton.ForeColor = System.Drawing.Color.White;
        }
        private void CalculateEvent(object sender, EventArgs e)
        {
            Messages message;
            try
            {
                if (Convert.ToBoolean(period.Value) & Convert.ToBoolean(amount.Value))
                {
                    AnalizerFile analizer = new AnalizerFile(fileData.Text.Trim());
                    if (analizer.IsValid())
                    {
                        List<float[]> data = new List<float[]>();
                        analizer.LoadData(out data);
                        Credito credito = new Credito((int)period.Value, (float)amount.Value, data);
                        credito.CalculateAmount();
                        CreditoReport report = new CreditoReport(credito);
                        report.MakeReport(out DataTable view);
                        reportView.DataSource = view.DefaultView;
                    }
                    else
                    {
                        throw new CException("File does not have right parameters", new FormatException());
                    }
                }
                else
                {
                    throw new CException("Period or amount not permited", new FormatException());
                }
            }
            catch(Exception ex)
            {
                message = new Messages(ex, "Mensaje de Sistema");
                message.InvokeMessage();
            }
        }
    }
}
