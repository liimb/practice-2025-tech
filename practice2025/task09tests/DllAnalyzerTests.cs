using System.Diagnostics;

namespace task09tests;

public class DllAnalyzerTests
{
    [Fact]
    public void ConsoleDllAnalyzer_HasExpectedPrint()
    {
        var baseDir = AppContext.BaseDirectory;
        var exePath = Path.Combine(baseDir, "task09");
        
        var projectPath = Path.GetFullPath(Path.Combine(baseDir, "../../../../task07/bin/Debug/net8.0/task07.dll"));
        
        string expected = "Класс: DisplayNameAttribute\nМетод:\nget_DisplayName\nМетод:\nEquals\nПараметры метода и их тип:\nobj Object\nМетод:\nGetHashCode\nМетод:\nget_TypeId\nМетод:\nMatch\nПараметры метода и их тип:\nobj Object\nМетод:\nIsDefaultAttribute\nМетод:\nGetType\nМетод:\nToString\nАтрибуты:\nNullableContextAttribute\nNullableAttribute\nAttributeUsageAttribute\nКонструкторы:\n.ctor\nПараметры конструктора и их тип:\nname String\n\nКласс: ReflectionHelper\nМетод:\nPrintTypeInfo\nПараметры метода и их тип:\ntype Type\nМетод:\nGetType\nМетод:\nToString\nМетод:\nEquals\nПараметры метода и их тип:\nobj Object\nМетод:\nGetHashCode\n\nКласс: SampleClass\nМетод:\nTestMethod\nМетод:\nget_Number\nМетод:\nset_Number\nПараметры метода и их тип:\nvalue String\nМетод:\nGetType\nМетод:\nToString\nМетод:\nEquals\nПараметры метода и их тип:\nobj Object\nМетод:\nGetHashCode\nАтрибуты:\nNullableContextAttribute\nNullableAttribute\nVersionAttribute\nDisplayNameAttribute\nКонструкторы:\n.ctor\n\nКласс: VersionAttribute\nМетод:\nget_Major\nМетод:\nget_Minor\nМетод:\nEquals\nПараметры метода и их тип:\nobj Object\nМетод:\nGetHashCode\nМетод:\nget_TypeId\nМетод:\nMatch\nПараметры метода и их тип:\nobj Object\nМетод:\nIsDefaultAttribute\nМетод:\nGetType\nМетод:\nToString\nАтрибуты:\nAttributeUsageAttribute\nКонструкторы:\n.ctor\nПараметры конструктора и их тип:\nmajor Int32\nminor Int32\n\nКласс: <>c\nМетод:\nGetType\nМетод:\nToString\nМетод:\nEquals\nПараметры метода и их тип:\nobj Object\nМетод:\nGetHashCode\nАтрибуты:\nSerializableAttribute\nCompilerGeneratedAttribute\nКонструкторы:\n.ctor\n\nКласс: <>c__DisplayClass0_0\nМетод:\nGetType\nМетод:\nToString\nМетод:\nEquals\nПараметры метода и их тип:\nobj Object\nМетод:\nGetHashCode\nАтрибуты:\nCompilerGeneratedAttribute\nКонструкторы:\n.ctor\n\n";
        
        var startInfo = new ProcessStartInfo
        {
            FileName = exePath,
            Arguments = $"\"{projectPath}\"",
            RedirectStandardOutput = true,
        };

        using var process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        process.WaitForExit();

        Assert.Equal(expected, process.StandardOutput.ReadToEnd());
    }
}
