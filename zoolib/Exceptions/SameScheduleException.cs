using System;
using System.Collections.Generic;
using System.Text;

namespace ZooLib.Exceptions
{
    [Serializable]
    public class SameScheduleException:Exception
    {
        public SameScheduleException(string message) : base(message) { }
    }
}
