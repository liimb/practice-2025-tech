namespace task17;

public class HardStop(ServerThread thread) : ICommand
{
    public void Execute()
    {
        if (!thread.IsCurrentThread)
            throw new InvalidOperationException("HardStop must be executed in the thread it stops.");
        Console.WriteLine("HardStop");
        thread.RequestHardStop();
    }
}
