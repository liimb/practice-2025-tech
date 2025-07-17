namespace task18;

public class SoftStop(ServerSchedulerThread thread) : ICommand
{
    public bool Execute()
    {
        if (!thread.IsCurrentThread) throw new InvalidOperationException();

        Console.WriteLine("SoftStop");
        thread.RequestSoftStop();
        return true;
    }
}
