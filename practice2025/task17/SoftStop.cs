namespace task17;

public class SoftStop(ServerThread thread) : ICommand
{
    public void Execute()
    {
        if (!thread.IsCurrentThread) throw new InvalidOperationException();
        
        Console.WriteLine("SoftStop");
        thread.RequestSoftStop();
    }
}
