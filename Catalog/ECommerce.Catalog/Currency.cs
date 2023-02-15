using System.Collections.ObjectModel;
using ECommerce.Catalog.Exceptions;

// ReSharper disable InconsistentNaming

namespace ECommerce.Catalog;

public record Currency(string Code, string Name, string PluralName, char Symbol)
{
    public static readonly Currency EUR = new("EUR", "Euro", "Euros", '€');

    public static readonly Currency GBP = new("GBP", "Pound", "Pounds", '£');

    public static readonly Currency USD = new("USD", "Dollar", "Dollars", '$');

    private static readonly IReadOnlyDictionary<string, Currency> Lookup =
        new ReadOnlyDictionary<string, Currency>((from c in new[] { EUR, GBP, USD } select (c.Code, c))
            .ToDictionary(tup => tup.Code, tup => tup.c));

    public static IReadOnlyList<Currency> GetAll()
    {
        return Lookup.Values.OrderBy(c => c.Code).ToList();
    }

    public static Currency GetDefaultCurrency()
    {
        return USD;
    }

    public static Currency GetByCode(string code)
    {
        try
        {
            return Lookup[code];
        }
        catch (KeyNotFoundException ex)
        {
            throw new CurrencyException($"invalid code: '{code}'.", ex);
        }
        catch (ArgumentNullException)
        {
            throw new CurrencyException("Currency code cannot be null.");
        }
    }
}