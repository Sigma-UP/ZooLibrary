using System;
using System.Collections.Generic;
using System.Text;

namespace ZooLib.Exceptions
{
    [Serializable]
    public class UnknownEmployeeTypeException:Exception
    {
        public UnknownEmployeeTypeException(string message) : base(message) { }
    }
}
