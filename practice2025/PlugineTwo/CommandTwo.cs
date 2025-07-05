using task10;

namespace PlugineTwo;

[PluginLoad]
public class CommandTwo : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Второй плагин");
    }
}
