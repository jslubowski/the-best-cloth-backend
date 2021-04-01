using System.Collections.Generic;
using TheBestCloth.BLL.Domain;

namespace TheBestCloth.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user, ICollection<string> roles);
    }
}
