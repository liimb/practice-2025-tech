using System.Collections.Concurrent;

namespace task17;

public class ServerThread
{
    private readonly BlockingCollection<ICommand> _queue = new();
    private readonly Thread _thread;
    private bool _isHardStopped;
    private bool _softStopRequested;
    public string Name => _thread.Name;

    public ServerThread(string name)
    {
        _thread = new Thread(Run)
        {
            IsBackground = true,
            Name = name
        };
    }

    public void Start() => _thread.Start();

    public void EnqueueCommand(ICommand command) => _queue.Add(command);

    private void Run()
    {
        try
        {
            while (!_isHardStopped)
            {
                if (_queue.TryTake(out var command, Timeout.Infinite))
                {
                    try
                    {
                        command.Execute();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (_softStopRequested && _queue.Count == 0)
                    break;
            }
        }
        finally
        {
            _queue.Dispose();
        }
    }

    public void RequestHardStop()
    {
        _isHardStopped = true;
        _queue.CompleteAdding();
    }

    public void RequestSoftStop()
    {
        _softStopRequested = true;
    }

    public bool IsCurrentThread => Thread.CurrentThread == _thread;
}
