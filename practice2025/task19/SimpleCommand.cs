namespace task19;

public class SimpleCommand : ICommand
{
    public bool Execute()
    {
        Console.WriteLine("Простая команда");
        return true;
    }
}
