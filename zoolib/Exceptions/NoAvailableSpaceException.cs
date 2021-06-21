using System;
using System.Collections.Generic;
using System.Text;

namespace ZooLib.Exceptions
{
    [Serializable]
    public class NoAvailableSpaceException : Exception
    {
        public NoAvailableSpaceException(string message) : base(message) { }
    }
}
