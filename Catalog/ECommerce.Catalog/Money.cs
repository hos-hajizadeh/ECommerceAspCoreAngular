namespace ECommerce.Catalog;

public record Money(decimal Amount, Currency Currency) 
{
    public static implicit operator decimal(Money money) => money.Amount;

    public static implicit operator string(Money money) => money.GetShortString();

    public string GetLongString()
    {
        if (Amount == decimal.One)
        {
            return $"1 {Currency.Name}";
        }
        if (decimal.Truncate(Amount) == Amount)
        {
            return $"{Amount:D} {Currency.PluralName}";
        }
        return $"{Amount:F2} {Currency.PluralName}";
    }

    public string GetShortString() => $"{Currency.Symbol}{Amount:F2}";

    public override string ToString() => GetShortString();
}