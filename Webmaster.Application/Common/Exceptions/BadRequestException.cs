using System;

namespace Webmaster.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
              : base(message)
        {
        }
    }
}
