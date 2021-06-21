using System;
using System.Collections.Generic;
using System.Text;

namespace ZooLib.Exceptions
{
    [Serializable]
    public class EnclosureIsAlreadyExistsException:Exception
    {
        public EnclosureIsAlreadyExistsException(string message) : base(message) { }
    }
}
