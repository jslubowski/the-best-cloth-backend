using Microsoft.Extensions.Primitives;
using TheBestCloth.API.Helpers;

namespace TheBestCloth.API.Interfaces
{
    public interface IAuthenticationService
    {
        Credentials DecodeBasicAuthenticationHeader(StringValues authenticationHeader);
    }
}
