namespace task11;

public static class CalculatorGenerator
{
    public static void GenerateCalculator()
    {
        string calculator = """
                            public class Calculator
                                    {
                                        public int Add(int a, int b) => a + b;
                                        public int Minus(int a, int b) => a - b;
                                        public int Mul(int a, int b) => a * b;
                                        public int Div(int a, int b) => a / b;
                                    }
                            """;
    }
}
