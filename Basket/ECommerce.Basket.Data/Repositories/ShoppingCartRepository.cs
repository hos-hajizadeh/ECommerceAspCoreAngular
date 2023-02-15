using ECommerce.Basket.Data.Entities;
using ECommerce.Basket.Data.Persistence.DbContexts;
using ECommerce.Basket.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Basket.Data.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly BasketContext _basketContext;

    public ShoppingCartRepository(BasketContext basketContext)
    {
        _basketContext = basketContext;
    }

    public async Task PutAsync(ShoppingCart cart)
    {
        var snapshot = cart.TakeSnapshot();

        await RemoveAsync(snapshot.UserId); //todo:opz and trx

        var shoppingCartEntity = new ShoppingCartEntity
        {
            UserId = snapshot.UserId,
            Items = snapshot.Items.Select(i => new ShoppingCartItemEntity
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList()
        };

        _basketContext.Add(shoppingCartEntity);
        await _basketContext.SaveChangesAsync();
    }

    public async Task<ShoppingCart?> FindByUserIdOrDefaultAsync(long userId)
    {
        var shoppingCartEntity = await _basketContext.ShoppingCarts
            .Include(i => i.Items)
            .FirstOrDefaultAsync(i => i.UserId == userId);

        if (shoppingCartEntity == null)
            return null;

        var shoppingCart = new ShoppingCart(userId);
        foreach (var cartItemEntity in shoppingCartEntity.Items)
            shoppingCart.Add(cartItemEntity.ProductId, cartItemEntity.Quantity);

        return shoppingCart;
    }

    public async Task<bool> RemoveAsync(long userId)
    {
        var shoppingCartEntity = await _basketContext.ShoppingCarts
            .FirstOrDefaultAsync(i => i.UserId == userId);

        if (shoppingCartEntity == null)
            return false;

        _basketContext.Remove(shoppingCartEntity);
        await _basketContext.SaveChangesAsync();

        return true;
    }
}