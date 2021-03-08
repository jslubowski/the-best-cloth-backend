using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
