using task18;

namespace task18tests;

public class ServerSchedulerThreadTests
{
    [Fact]
    public void LongRunningCommand_ShouldExecuteInSteps()
    {
        var scheduler = new RoundRobinScheduler();
        var server = new ServerSchedulerThread(scheduler);
        var longCommand = new SomeLongCommand(3);
        var simpleCommand = new SomeCommand();

        using var sw = new StringWriter();
        Console.SetOut(sw);

        server.Start();
        server.EnqueueCommand(simpleCommand);
        server.EnqueueCommand(longCommand);
        server.EnqueueCommand(simpleCommand);
        server.EnqueueCommand(new SoftStop(server));
        server.Join();

        var output = sw.ToString();
        const string expected = "Простая команда\nВыполнений осталось: 2\nВыполнений осталось: 1\nВыполнений осталось: 0\nПростая команда\nSoftStop\n";
        
        Assert.Equal(expected, output);
    }
}
