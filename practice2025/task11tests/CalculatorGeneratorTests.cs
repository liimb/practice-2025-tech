using task11;

namespace task11tests;

public class CalculatorGeneratorTests
{
    private static readonly ICalculator? Calculator;

    static CalculatorGeneratorTests()
    {
        Calculator = CalculatorGenerator.GenerateCalculator();
    }
    
    [Fact]
    public void CalculatorGenerator_CorrectPlusMethod()
    {
        Assert.NotNull(Calculator);
        Assert.Equal(59, Calculator.Add(25, 34));
    }

    [Fact]
    public void CalculatorGenerator_CorrectMinusMethod()
    {
        Assert.NotNull(Calculator);
        Assert.Equal(1000, Calculator.Minus(1123, 123));
    }

    [Fact]
    public void CalculatorGenerator_CorrectMulMethod()
    {
        Assert.NotNull(Calculator);
        Assert.Equal(225, Calculator.Mul(45, 5));
    }

    [Fact]
    public void CalculatorGenerator_CorrectDivMethod()
    {
        Assert.NotNull(Calculator);
        Assert.Equal(10, Calculator.Div(50, 5));
    }
}
