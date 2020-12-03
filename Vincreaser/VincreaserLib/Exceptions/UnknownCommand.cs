using System;

namespace VincreaserLib.Exceptions
{
    public class UnknownCommand : Exception
    {
        public UnknownCommand(string exceptionMessage)
            : base(exceptionMessage)
        {
        }
    }
}
