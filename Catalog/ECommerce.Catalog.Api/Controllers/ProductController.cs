using ECommerce.Catalog.Application.Queries;
using ECommerce.Web.Framework.Mvc.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ServiceFilter(typeof(ValidationFilter))]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetProductsQuery());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var response = await _mediator.Send(new GetProductQuery()
        {
            Id = id
        });
        return Ok(response);
    }
}