using task10;

namespace task10tests;

public class LibrariesLoaderTests
{
    [Fact]
    public void LibrariesLoader_HasCorrectConsolePrint()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        
        string expected = "Первый плагин\nПервый плагин\nВторой плагин\nПервый плагин\nВторой плагин\nТретий плагин\n";

        string path = Path.Combine(AppContext.BaseDirectory, "../../../Plugins"); 
        
        /*
         * Для примера было создано 3 плагина, их .dll помещены в папку Plugins.
         * Первый плагин корневой. Второй зависит от первого, третий - от второго.
         * Каждый плагин вызывает метод Execute плагина, от которого зависит (на 1 предка вверх)
        */
        
        LibrariesLoader.Load(path);
        
        Assert.Equal(expected, output.ToString());
    }
}
