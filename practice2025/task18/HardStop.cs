namespace task18;

public class HardStop(ServerSchedulerThread thread) : ICommand
{
    public bool Execute()
    {
        if (!thread.IsCurrentThread) throw new InvalidOperationException();

        Console.WriteLine("HardStop");
        thread.RequestHardStop();
        return true;
    }
}
