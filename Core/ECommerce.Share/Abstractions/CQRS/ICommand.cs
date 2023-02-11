namespace ECommerce.Share.Abstractions.CQRS;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}