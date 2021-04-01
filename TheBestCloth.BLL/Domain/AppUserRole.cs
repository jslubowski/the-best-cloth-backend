using Microsoft.AspNetCore.Identity;

namespace TheBestCloth.BLL.Domain
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public AppRole Role { get; set; }
    }
}
