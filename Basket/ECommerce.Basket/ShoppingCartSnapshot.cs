namespace ECommerce.Basket;

public record ShoppingCartSnapshot(long UserId, IEnumerable<ShoppingCartItemSnapshot> Items);