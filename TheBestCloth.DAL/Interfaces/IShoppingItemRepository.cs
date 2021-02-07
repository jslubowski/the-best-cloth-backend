using System.Threading.Tasks;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.DAL.Interfaces
{
    public interface IShoppingItemRepository
    {
        Task<bool> AddShoppingItem(ShoppingItem shoppingItem);
        Task<bool> RemoveShoppingItem(ShoppingItem shoppingItem);

    }
}
