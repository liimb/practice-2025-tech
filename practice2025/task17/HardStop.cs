namespace task17;

public class HardStop(ServerThread thread) : ICommand
{
    public void Execute()
    {
        if (!thread.IsCurrentThread) throw new InvalidOperationException();
        
        Console.WriteLine("HardStop");
        thread.RequestHardStop();
    }
}
