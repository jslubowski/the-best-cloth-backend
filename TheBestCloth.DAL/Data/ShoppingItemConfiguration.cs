using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheBestCloth.BLL.Domain;

namespace TheBestCloth.DAL.Data
{
    class ShoppingItemConfiguration : IEntityTypeConfiguration<ShoppingItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingItem> builder)
        {
            builder.HasMany(shoppingItem => shoppingItem.Photos)
                .WithOne(photo => photo.ShoppingItem)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
