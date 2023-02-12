using ECommerce.Basket.Repositories;

namespace ECommerce.Basket.Application.Commands;

public class RemoveProductFromShoppingCartCommand : ICommand<bool>
{
    public long ProductId { get; set; }

    public class Handler : ICommandHandler<RemoveProductFromShoppingCartCommand, bool>
    {
        private readonly IWorkContext _workContext;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public Handler(IWorkContext workContext, IShoppingCartRepository shoppingCartRepository)
        {
            _workContext = workContext;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<bool> Handle(RemoveProductFromShoppingCartCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _workContext.GetCurrentUserId();
            var card = await _shoppingCartRepository.FindByUserIdOrDefaultAsync(userId);
            if (card is null)
                return false;

            card.Remove(request.ProductId);
            await _shoppingCartRepository.PutAsync(card);
            return true;
        }
    }
}