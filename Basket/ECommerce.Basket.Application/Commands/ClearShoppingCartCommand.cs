using ECommerce.Basket.Repositories;

namespace ECommerce.Basket.Application.Commands;

public class ClearShoppingCartCommand : ICommand<bool>
{
    public static ClearShoppingCartCommand Default = new();

    public class Handler : ICommandHandler<ClearShoppingCartCommand, bool>
    {
        private readonly IWorkContext _workContext;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public Handler(IWorkContext workContext, IShoppingCartRepository shoppingCartRepository)
        {
            _workContext = workContext;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<bool> Handle(ClearShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var userId = _workContext.GetCurrentUserId();
            var card = await _shoppingCartRepository.FindByUserIdOrDefaultAsync(userId);
            if (card is null)
                return false;

            card.Clear();
            await _shoppingCartRepository.PutAsync(card);
            return true;
        }
    }
}