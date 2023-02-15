namespace ECommerce.Catalog;

public record Money(decimal Amount, Currency Currency)
{
    public static implicit operator decimal(Money money)
    {
        return money.Amount;
    }

    public static implicit operator string(Money money)
    {
        return money.GetShortString();
    }

    public string GetLongString()
    {
        if (Amount == decimal.One) return $"1 {Currency.Name}";
        if (decimal.Truncate(Amount) == Amount) return $"{Amount:D} {Currency.PluralName}";
        return $"{Amount:F2} {Currency.PluralName}";
    }

    public string GetShortString()
    {
        return $"{Currency.Symbol}{Amount:F2}";
    }

    public override string ToString()
    {
        return GetShortString();
    }
}