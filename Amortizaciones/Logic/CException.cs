using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections;

namespace Amortizaciones.Logic
{
    [Serializable]
    public sealed class CException : Exception
    {
        public CException() { }
        public CException(String message) : base(message) { }
        public CException(String message, Exception innerException):base(message, innerException) { }
        private CException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public string GetMessage()
        {
            return base.Message;
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
