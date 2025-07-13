using task14;

namespace task14tests;

public class DefiniteIntegralTests
{
    private readonly Func<double, double> _x = x => x;
    private readonly Func<double, double> _sin = Math.Sin;
    private readonly Func<double, double> _sinCos = x => Math.Sin(x) * Math.Cos(x);

    [Fact]
    public void DefiniteIntegralTest_FuncLinearFirstCorrectCalculation()
    {
        Assert.Equal(0, DefiniteIntegral.Solve(-1, 1, _x, 1e-4, 2), 1e-4);
    }
    
    [Fact]
    public void DefiniteIntegralTest_FuncSinFirstCorrectCalculation()
    {
        Assert.Equal(0, DefiniteIntegral.Solve(-1, 1, _sin, 1e-5, 8), 1e-4);
    }
    
    [Fact]
    public void DefiniteIntegralTest_FuncSinSecondCorrectCalculation()
    {
        Assert.Equal(0.2566, DefiniteIntegral.Solve(-1, 5, _sin, 1e-5, 1), 1e-4);
    }
    
    [Fact]
    public void DefiniteIntegralTest_FuncLinearSecondCorrectCalculation()
    {
        Assert.Equal(12.5, DefiniteIntegral.Solve(0, 5, _x, 1e-6, 8), 1e-5);
    }
    
    [Fact]
    public void DefiniteIntegralTest_FuncSinCosCorrectCalculation()
    {
        Assert.Equal(0.268, DefiniteIntegral.Solve(10, 20, _sinCos, 1e-1, 10), 1e-2);
    }
}
