using System;

namespace TheBestCloth.API.Exceptions
{
    public class CloudinaryConnectionException : Exception
    {
        public CloudinaryConnectionException(string message) : base(message)
        {

        }
    }
}
