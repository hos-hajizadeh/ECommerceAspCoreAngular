using ECommerce.AntiCorruptionLayer.CatalogBasket;
using ECommerce.Basket.Data.Persistence.DbContexts;
using ECommerce.Basket.Data.Repositories;
using ECommerce.Basket.Repositories;
using ECommerce.Catalog.Data.AntiCorruptions;
using ECommerce.Catalog.Data.Entities;
using ECommerce.Catalog.Data.Persistence.DbContexts;
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
        protected const long ProductId = 3;
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
            services.AddScoped<ICatalogBasketACL, CatalogBasketACL>();

            services.AddSingleton(_mockWorkContext.Object);

            services.AddDbContext<BasketContext>((sp, options) =>
            {
                options.UseInMemoryDatabase("BasketContext").UseInternalServiceProvider(sp);
            });

            services.AddDbContext<CatalogContext>((sp, options) =>
            {
                options.UseInMemoryDatabase("CatalogContext").UseInternalServiceProvider(sp);
            });

            _serviceProvider = services.BuildServiceProvider();

            _mediator = _serviceProvider.GetService<IMediator>()!;
            _shoppingCartRepository = _serviceProvider.GetService<IShoppingCartRepository>()!;

            SeedCatalogContext();
        }

        private void SeedCatalogContext()
        {
            var catalogContext = _serviceProvider.GetService<CatalogContext>()!;

            var productEntities = new List<ProductEntity>
            {
                new()
                {
                    Id = 1,
                    Name = "Product A",
                    Price = new Money()
                    {
                        Amount = 100,
                        Currency = "USD"
                    },
                    Description = "Product A ........."
                },
                new()
                {
                    Id = 2,
                    Name = "Product B",
                    Price = new Money()
                    {
                        Amount = 150,
                        Currency = "USD"
                    },
                    Description = "Product B ........."
                },
                new()
                {
                    Id = 3,
                    Name = "Product C",
                    Price = new Money()
                    {
                        Amount = 200,
                        Currency = "USD"
                    },
                    Description = "Product C ........."
                }
            };

            catalogContext.Products.AddRange(productEntities);
            catalogContext.SaveChanges();
        }
    }
}