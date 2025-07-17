namespace task19;

public class TestCommand(int id) : ICommand
{
    private int _counter;

    public bool Execute()
    {
        Console.WriteLine($"Поток {id} вызов {++_counter}");
        return _counter >= 3;
    }
}
