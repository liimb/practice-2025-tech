using PlugineOne;
using task10;

namespace PlugineTwo;

[PluginLoad]
public class CommandTwo : ICommand
{
    public void Execute()
    {
        var c = new CommandOne();
        c.Execute();
        Console.WriteLine("Второй плагин");
    }
}
