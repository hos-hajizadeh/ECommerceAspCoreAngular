namespace ECommerce.Basket.Repositories;

public interface IShoppingCartRepository
{
    Task PutAsync(ShoppingCart cart);
    Task<ShoppingCart?> FindByUserIdOrDefaultAsync(long userId);
    Task<bool> RemoveAsync(long userId);
}