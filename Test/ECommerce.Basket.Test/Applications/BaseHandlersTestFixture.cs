using ECommerce.Basket.Data.Persistence.DbContexts;
using ECommerce.Basket.Data.Repositories;
using ECommerce.Basket.Repositories;
using ECommerce.Share.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace ECommerce.Basket.Test.Applications
{
    public abstract class BaseHandlersTestFixture
    {
        protected const int UserId = 10;
        protected const long ProductId = 10;
        protected const int Quantity = 2;
        
        protected Mock<IWorkContext> _mockWorkContext = new();
        protected IMediator _mediator;
        protected ServiceProvider _serviceProvider;
        protected IShoppingCartRepository _shoppingCartRepository;
  
        protected BaseHandlersTestFixture()
        {
            _mockWorkContext.Setup(x => x.GetCurrentUserId()).Returns(UserId);

            var services = new ServiceCollection();
            services.AddEntityFrameworkInMemoryDatabase();
            services.AddMediatR(typeof(Application.DependencyInjectionExtensions));
            services.AddMediatR(typeof(Basket.Data.DependencyInjectionExtensions));
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddSingleton(_mockWorkContext.Object);

            services.AddDbContext<BasketContext>((sp, options) =>
            {
                options.UseInMemoryDatabase("TestDb").UseInternalServiceProvider(sp);
            });

            _serviceProvider = services.BuildServiceProvider();

            _mediator = _serviceProvider.GetService<IMediator>()!;
            _shoppingCartRepository = _serviceProvider.GetService<IShoppingCartRepository>()!;
        }
    }
}