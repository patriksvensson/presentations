using Xunit;

namespace TaxCalculator.Tests;

public class TaxCalculatorTests
{
    [Fact]
    public void Should_Return_Correct_Tax()
    {
        // Given, When
        var result = TaxCalculator.Calculate(100m);

        // Then
        Assert.Equal(125, result.PriceIncludingTax);
        Assert.Equal(25, result.Tax);
    }
}