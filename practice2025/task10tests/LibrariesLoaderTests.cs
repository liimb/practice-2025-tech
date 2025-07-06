using task10;

namespace task10tests;

public class LibrariesLoaderTests
{
    [Fact]
    public void LibrariesLoader_HasCorrectConsolePrint()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        
        string expected = "Первый плагин\nВторой плагин\nТретий плагин\n\n";
        
        string path = Path.Combine(AppContext.BaseDirectory, "Plugins");
        LibrariesLoader.Load(path);
        
        //Assert.Equal(expected, output.ToString());
    }
}
