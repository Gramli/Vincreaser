using System;

namespace VincreaserLib.Exceptions
{
    public class PathException : Exception
    {
        public PathException(string exceptionMessage)
            : base(exceptionMessage)
        {
        }
    }
}
