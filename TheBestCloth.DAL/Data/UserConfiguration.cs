using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheBestCloth.BLL.Domain;

namespace TheBestCloth.DAL.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(user => user.UserRoles)
                .WithOne(role => role.User)
                .HasForeignKey(role => role.UserId)
                .IsRequired();
        }
    }
}
