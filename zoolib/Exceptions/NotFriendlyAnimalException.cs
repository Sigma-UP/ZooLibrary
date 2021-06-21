using System;
using System.Collections.Generic;
using System.Text;

namespace ZooLib.Exceptions
{
    [Serializable]
    public class NotFriendlyAnimalException : Exception
    {
        public NotFriendlyAnimalException(string message) : base(message) { }
    }
}
