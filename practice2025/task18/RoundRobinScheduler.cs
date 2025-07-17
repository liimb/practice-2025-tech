namespace task18;

public class RoundRobinScheduler : IScheduler
{
    private readonly Queue<ICommand> _queue = new();
    private readonly object _lock = new();

    public bool HasCommand()
    {
        lock (_lock) return _queue.Count > 0;
    }

    public ICommand Select()
    {
        lock (_lock)
        {
            if (_queue.Count == 0) return null!;
            var cmd = _queue.Dequeue();
            return cmd;
        }
    }

    public void Add(ICommand cmd)
    {
        lock (_lock) _queue.Enqueue(cmd);
    }
}
