using ECommerce.Basket.Api.Models;
using ECommerce.Basket.Application.Commands;
using ECommerce.Basket.Application.Queries;
using ECommerce.Web.Framework.Mvc.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Basket.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ServiceFilter(typeof(ValidationFilter))]
public class ShoppingCartController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShoppingCartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetUserShoppingCartQuery());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductToShoppingCartRequest request)
    {
        var response = await _mediator.Send(new AddProductToShoppingCartCommand
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity
        });
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProduct(long id)
    {
        var response = await _mediator.Send(new RemoveProductFromShoppingCartCommand
        {
            ProductId = id
        });
        return Ok(response);
    }

    [HttpDelete("Clear")]
    public async Task<IActionResult> Clear()
    {
        var response = await _mediator.Send(ClearShoppingCartCommand.Default);
        return Ok(response);
    }

    [HttpPost("Purchase")]
    public async Task<IActionResult> Purchase([FromBody] PurchaseRequest request) //todo:its fake Purchase
    {
        var response = await _mediator.Send(ClearShoppingCartCommand.Default);
        return Ok(response);
    }
}