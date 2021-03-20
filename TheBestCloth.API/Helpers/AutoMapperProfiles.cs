using AutoMapper;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>();
        }
    }
}
