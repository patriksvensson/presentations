namespace TaxCalculator;

public static class TaxCalculator
{
    public static (decimal PriceIncludingTax, decimal Tax) Calculate(decimal price)
    {
        return (price * 1.25m, price * 0.25m);
    }
}
