using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MCServerLib.Exceptions
{
    public class JavaNotFound : Exception
    {
        public JavaNotFound() : base()
        {
        }

        public JavaNotFound(string Message) : base()
        {
        }

        public JavaNotFound(string Message, Exception innerException) : base()
        {
        }

        protected JavaNotFound(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
