namespace task18;

public class SomeCommand : ICommand
{
    public bool Execute()
    {
        Console.WriteLine("Простая команда");
        return true;
    }
}
