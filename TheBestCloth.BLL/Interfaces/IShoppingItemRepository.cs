﻿using System.Threading.Tasks;
using TheBestCloth.BLL.Helpers;
using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.BLL.Interfaces
{
    public interface IShoppingItemRepository
    {
        Task<ShoppingItem> AddShoppingItemAsync(ShoppingItem shoppingItem);
        Task<bool> RemoveShoppingItemAsync(int id);
        Task<ShoppingItem> GetShoppingItemByIdAsync(int id);
        Task<IEnumerable<ShoppingItem>> GetAllShoppingItemsListAsync(PaginationParams paginationParams);
        Task<ShoppingItem> UpdateShoppingItemAsync(ShoppingItem shoppingItem);
    }
}