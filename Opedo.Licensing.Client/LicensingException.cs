using System;
using System.Collections.Generic;
using System.Text;

namespace Opedo.Licensing.Client
{

    [Serializable]
    public class LicensingException : Exception
    {
        public LicensingException() { }
        public LicensingException(string message) : base(message) { }
        public LicensingException(string message, Exception inner) : base(message, inner) { }
        protected LicensingException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
