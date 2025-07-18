using task19;

namespace task19tests;

public class ServerSchedulerThreadTests
{
    [Fact]
    public void TestCommands_ShouldExecuteEachThreeTimes_ThenHardStop()
    {
        var scheduler = new RoundRobinScheduler();
        var server = new ServerSchedulerThread(scheduler);

        using var sw = new StringWriter();
        Console.SetOut(sw);

        server.EnqueueCommand(new TestCommand(1));
        server.EnqueueCommand(new TestCommand(2));
        server.EnqueueCommand(new TestCommand(3));
        server.EnqueueCommand(new TestCommand(4));
        server.EnqueueCommand(new TestCommand(5));

        server.Start();
        server.EnqueueCommand(new SoftStop(server));
        server.Join();

        var output = sw.ToString();
        
        const string expected =
            "Поток 1 вызов 1\nПоток 1 вызов 2\nПоток 2 вызов 1\nПоток 1 вызов 3\nПоток 3 вызов 1\n" +
            "Поток 2 вызов 2\nПоток 4 вызов 1\nПоток 3 вызов 2\nПоток 5 вызов 1\nПоток 2 вызов 3\n" +
            "SoftStop\nПоток 4 вызов 2\nПоток 3 вызов 3\nПоток 5 вызов 2\nПоток 4 вызов 3\nПоток 5 вызов 3\n";

        Assert.Equal(expected, output);
    }
    
    [Fact]
    public void HardStop_ShouldStopImmediatelyAndNotFinishCommands()
    {
        var scheduler = new RoundRobinScheduler();
        var server = new ServerSchedulerThread(scheduler);

        using var sw = new StringWriter();
        Console.SetOut(sw);

        server.EnqueueCommand(new TestCommand(1));
        server.EnqueueCommand(new TestCommand(2));
        server.EnqueueCommand(new TestCommand(3));
        server.EnqueueCommand(new TestCommand(4));
        server.EnqueueCommand(new TestCommand(5));
        server.EnqueueCommand(new HardStop(server));
        
        server.Start();
        server.Join();

        const string expected = 
            "Поток 1 вызов 1\nПоток 1 вызов 2\nПоток 2 вызов 1\nПоток 1 вызов 3\nПоток 3 вызов 1\n" +
            "Поток 2 вызов 2\nПоток 4 вызов 1\nПоток 3 вызов 2\nПоток 5 вызов 1\nПоток 2 вызов 3\n" +
            "HardStop\n";
        
        var output = sw.ToString();
        
        Assert.Equal(expected, output);
    }
}
