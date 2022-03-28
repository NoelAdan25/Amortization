using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortizaciones.Logic
{
    class CException: Exception
    {
        private String messageR;
        private Exception innerExceptions;
        public CException() { }
        public CException(String message):base(message)
        {
            this.MessageR = message;
        }
        public CException(String message, Exception innerException):base(message, innerException)
        {
            this.messageR = message;
            this.InnerExceptions = innerException;
        }
        public string MessageR { get => messageR; private set => messageR = value; }
        public Exception InnerExceptions { get => innerExceptions; private set => innerExceptions = value; }
    }
}
