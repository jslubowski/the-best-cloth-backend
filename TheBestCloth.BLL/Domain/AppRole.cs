using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TheBestCloth.BLL.Domain
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
