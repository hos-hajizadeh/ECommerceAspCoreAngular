using ECommerce.Catalog.Application.Dtos;

namespace ECommerce.Catalog.Application.Queries;

public class GetProductQuery : IQuery<ProductOverviewDto>
{
    public long Id { get; set; }
}