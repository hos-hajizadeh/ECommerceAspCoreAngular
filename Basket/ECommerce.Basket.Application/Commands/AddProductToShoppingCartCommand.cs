using ECommerce.Basket.Repositories;

namespace ECommerce.Basket.Application.Commands;

public class AddProductToShoppingCartCommand : ICommand<bool>
{
    public long ProductId { get; set; }
    public int Quantity { get; set; }

    public class Handler : ICommandHandler<AddProductToShoppingCartCommand, bool>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IWorkContext _workContext;

        public Handler(IWorkContext workContext, IShoppingCartRepository shoppingCartRepository)
        {
            _workContext = workContext;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<bool> Handle(AddProductToShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var userId = _workContext.GetCurrentUserId();

            var card = await _shoppingCartRepository.FindByUserIdOrDefaultAsync(userId);
            if (card is null)
            {
                card = new ShoppingCart(userId);
                card.Add(request.ProductId, request.Quantity);
            }
            else
            {
                card.Add(request.ProductId, request.Quantity);
            }

            await _shoppingCartRepository.PutAsync(card);

            return true;
        }
    }
}