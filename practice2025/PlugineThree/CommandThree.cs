using task10;

namespace PlugineThree;

[PluginLoad]
public class CommandThree : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Третий плагин");
    }
}
