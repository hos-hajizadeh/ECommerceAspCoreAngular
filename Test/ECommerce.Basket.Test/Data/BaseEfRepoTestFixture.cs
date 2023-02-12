using ECommerce.Basket.Data.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Basket.Test.Data
{
    public abstract class BaseEfRepoTestFixture
    {
        protected BasketContext _dbContext;

        protected BaseEfRepoTestFixture()
        {
            var collection = new ServiceCollection();
            collection.AddEntityFrameworkInMemoryDatabase();

            collection.AddDbContext<BasketContext>((sp, options) =>
            {
                options.UseInMemoryDatabase("TestDb").UseInternalServiceProvider(sp);
            });

            var serviceProvider =collection .BuildServiceProvider();

            _dbContext = serviceProvider.GetService<BasketContext>()!;
        }
    }
}