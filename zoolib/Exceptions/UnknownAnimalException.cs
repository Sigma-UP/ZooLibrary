using System;
using System.Collections.Generic;
using System.Text;

namespace ZooLib.Exceptions
{
    [Serializable]
    public class UnknownAnimalException : Exception
    {
        public UnknownAnimalException(string message) : base(message) { }
    }
}
