using System.Collections.Concurrent;

namespace task18;

public class ServerSchedulerThread
{
    private readonly Thread _thread;
    private readonly BlockingCollection<ICommand> _queue = new();
    private readonly IScheduler _scheduler;
    private bool _running = true;
    private bool _softStopRequested;

    public ServerSchedulerThread(IScheduler scheduler)
    {
        _scheduler = scheduler;
        _thread = new Thread(Run) { IsBackground = true };
    }

    public void Start() => _thread.Start();
    
    public void Join() => _thread.Join();

    public void EnqueueCommand(ICommand cmd)
    {
        _queue.Add(cmd);
    }

    private void Run()
    {
        while (_running)
        {
            if (_scheduler.HasCommand())
            {
                var scheduledCmd = _scheduler.Select();
                if (!scheduledCmd.Execute())
                {
                    _scheduler.Add(scheduledCmd);
                }
                continue;
            }

            if (!_queue.TryTake(out var newCmd, TimeSpan.FromMilliseconds(100))) continue;
            
            if (!newCmd.Execute())
            {
                _scheduler.Add(newCmd);
            }
            
            if (_softStopRequested && _queue.Count == 0 && !_scheduler.HasCommand())
                break;
        }
    }
    
    public void RequestSoftStop()
    {
        _softStopRequested = true;
    }
    
    public void RequestHardStop()
    {
        _running = false;
    }

    public bool IsCurrentThread => Thread.CurrentThread == _thread;
}
