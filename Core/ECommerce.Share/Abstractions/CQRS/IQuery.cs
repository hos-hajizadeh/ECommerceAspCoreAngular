namespace ECommerce.Share.Abstractions.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}