using PlugineTwo;
using task10;

namespace PlugineThree;

[PluginLoad]
public class CommandThree : ICommand
{
    public void Execute()
    {
        var c = new CommandTwo();
        c.Execute();
        Console.WriteLine("Третий плагин");
    }
}
