using task14;

namespace task14tests;

public class DefiniteIntegralTests
{
    private readonly Func<double, double> _x = x => x;
    private readonly Func<double, double> _sin = Math.Sin;

    [Fact]
    public void DefiniteIntegralTest_FuncLinearFirstCorrectCalculation()
    {
        Assert.Equal(0, DefiniteIntegral.Solve(-1, 1, _x, 1e-4, 2), 1e-4);
    }
    
    [Fact]
    public void DefiniteIntegralTest_FuncSinCorrectCalculation()
    {
        Assert.Equal(0, DefiniteIntegral.Solve(-1, 1, _sin, 1e-5, 8), 1e-4);
    }
    
    [Fact]
    public void DefiniteIntegralTest_FuncLinearSecondCorrectCalculation()
    {
        Assert.Equal(12.5, DefiniteIntegral.Solve(0, 5, _x, 1e-6, 8), 1e-5);
    }
}
