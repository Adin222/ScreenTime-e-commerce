using ScreenTime.Models;

namespace ScreenTime.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole);
    }
}
