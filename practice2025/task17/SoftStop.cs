namespace task17;

public class SoftStop(ServerThread thread) : ICommand
{
    public void Execute()
    {
        if (!thread.IsCurrentThread)
            throw new InvalidOperationException("SoftStop must be executed in the thread it stops.");
        Console.WriteLine("SoftStop");
        thread.RequestSoftStop();
    }
}
