using task10;

namespace PlugineOne;

[PluginLoad]
public class CommandOne : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Первый плагин");
    }
}
