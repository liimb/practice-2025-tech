namespace task17tests;
using task17;

public class ServerThreadTests
{
    [Fact]
    public void SoftStop_ShouldExecuteAllCommandsAndStop()
    {
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        
        var thread = new ServerThread("SoftStopTest");
        thread.Start();

        thread.EnqueueCommand(new LongServerCommand());
        thread.EnqueueCommand(new SoftStop(thread));
        thread.EnqueueCommand(new LongServerCommand());
        thread.EnqueueCommand(new LongServerCommand());

        thread.Join();

        var output = consoleOutput.ToString();
        const string expected = "LongServerCommand\nSoftStop\nLongServerCommand\nLongServerCommand\n";
        
        Assert.Equal(expected, output);
    }
    
    [Fact]
    public void HardStop_ShouldStopImmediately()
    {
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        
        var thread = new ServerThread("HardStopTest");
        thread.Start();

        thread.EnqueueCommand(new LongServerCommand());
        thread.EnqueueCommand(new HardStop(thread));
        thread.EnqueueCommand(new LongServerCommand());
        thread.EnqueueCommand(new LongServerCommand());

        thread.Join();

        var output = consoleOutput.ToString();
        const string expected = "LongServerCommand\nHardStop\n";
        
        Assert.Equal(expected, output);
    }
    
    [Fact]
    public void HardStop_ShouldThrowIfCalledFromAnotherThread()
    {
        var thread = new ServerThread("Thread");
        thread.Start();
        var command = new HardStop(thread);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }

    [Fact]
    public void SoftStop_ShouldThrowIfCalledFromAnotherThread()
    {
        var thread = new ServerThread("Thread1");
        var command = new SoftStop(thread);
        
        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }
}
