using ECommerce.Share.Exceptions;

namespace ECommerce.Catalog.Exceptions;

public class CurrencyException : DomainException
{
    public CurrencyException()
    {
    }

    public CurrencyException(string message) : base(message)
    {
    }

    public CurrencyException(string message, Exception innerException) : base(message, innerException)
    {
    }
}