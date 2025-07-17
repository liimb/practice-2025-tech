namespace task18;

public class SomeLongCommand(int steps) : ICommand
{
    private int _stepsLeft = steps;
    
    public bool Execute()
    {
        _stepsLeft--;
        Console.WriteLine($"Выполнений осталось: {_stepsLeft}");
        return _stepsLeft <= 0;
    }
}
