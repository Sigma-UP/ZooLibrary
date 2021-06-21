using System;

namespace ZooLib.Exceptions
{
    [Serializable]
    public class NotFavoriteFoodException : Exception
    {
        public NotFavoriteFoodException(string message) : base(message) { }
    }
}
