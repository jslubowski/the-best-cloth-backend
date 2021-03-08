using Microsoft.Extensions.Primitives;
using System;
using System.Text;
using TheBestCloth.API.Helpers;
using TheBestCloth.API.Interfaces;

namespace TheBestCloth.API.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {
            _authorizationHeaderPrefix = "Basic ";
            _separatorIndex = ':';
            _encodingType = "iso-8859-1";
            _usernameIndex = 0;
            _passwordIndex = 1;
        }
        private readonly string _authorizationHeaderPrefix;
        private readonly char _separatorIndex;
        private readonly int _usernameIndex;
        private readonly int _passwordIndex;
        private readonly string _encodingType;

        public Credentials DecodeBasicAuthenticationHeader(StringValues authenticationHeader)
        {
            string stringHeader = authenticationHeader.ToString();

            if (stringHeader == null && !stringHeader.StartsWith(_authorizationHeaderPrefix))
                return null;

            string encodedUsernamePassword = stringHeader.Substring(_authorizationHeaderPrefix.Length).Trim();

            Encoding encoding = Encoding.GetEncoding(_encodingType);
            string credentialsEncoded = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

            return new Credentials
            {
                Username = credentialsEncoded.Split(_separatorIndex)[_usernameIndex],
                Password = credentialsEncoded.Split(_separatorIndex)[_passwordIndex]
            };

        }
    }
}
