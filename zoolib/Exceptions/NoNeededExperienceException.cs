using System;
using System.Collections.Generic;
using System.Text;

namespace ZooLib.Exceptions
{
    [Serializable]
    public class NoNeededExperienceException : Exception
    {
        public NoNeededExperienceException(string message) : base(message) { }
    }
}
