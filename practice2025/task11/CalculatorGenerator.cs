using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace task11;

public static class CalculatorGenerator
{
    public static ICalculator? GenerateCalculator()
    {
        string code = """
                            using task11;
                            
                            public class Calculator : ICalculator
                                    {
                                        public int Add(int a, int b) => a + b;
                                        public int Minus(int a, int b) => a - b;
                                        public int Mul(int a, int b) => a * b;
                                        public int Div(int a, int b) => a / b;
                                    }
                            """;
        
        var syntaxTree = CSharpSyntaxTree.ParseText(code);

        var references = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
            .Select(a => MetadataReference.CreateFromFile(a.Location))
            .ToList();
        
        var compilation = CSharpCompilation.Create(
            assemblyName: "Calculator",
            syntaxTrees: [syntaxTree],
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
        );

        using var ms = new MemoryStream();
        compilation.Emit(ms);

        ms.Seek(0, SeekOrigin.Begin);
        var assembly = AssemblyLoadContext.Default.LoadFromStream(ms);
        var type = assembly.GetType("Calculator");
        
        if (type == null) return null;
        
        var instance = Activator.CreateInstance(type);

        ICalculator calculator = (ICalculator)instance!;
        
        return calculator;
    }
}
