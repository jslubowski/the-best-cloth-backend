using System;

namespace TheBestCloth.BLL.Exceptions
{
    public class RegisterException : Exception
    {
        public RegisterException(string message): base(message) {}
    }
}
