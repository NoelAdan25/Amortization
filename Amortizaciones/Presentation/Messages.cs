using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amortizaciones.Presentation
{
    class Messages
    {
        private String messageText;
        private String motivo;
        public Messages() { }
        public Messages(String messageText, String motivo)
        {
            this.messageText = messageText;
            this.motivo = motivo;
        }
        public Messages(Exception ex, String motivo)
        {
            this.messageText = ex.Message + "." + System.Environment.NewLine + ex.InnerException.Message;
            this.motivo = motivo;
        }
        public string MessageText { get => this.messageText; set => this.messageText = value; }
        public string Motivo { get => this.motivo; set => this.motivo = value; }
        public void InvokeMessage() => MessageBox.Show(MessageText, Motivo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        public DialogResult InvokeMessageResult(MessageBoxButtons messageBoxButtons)
        {
            return MessageBox.Show(MessageText, Motivo, messageBoxButtons, MessageBoxIcon.Information);
        }
    }
}
