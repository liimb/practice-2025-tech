namespace task14;

public static class DefiniteIntegral
{
    public static double Solve(double a, double b, Func<double, double> function, double step, int threadsNumber)
    {
        var stepCount = (int)((b - a) / step);

        var result = 0d;
        var stepCountPerThread = stepCount / threadsNumber;

        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = threadsNumber
        };

        object locker = new();

        Parallel.For(0, threadsNumber, options, i =>
        {
            var start = i * stepCountPerThread;
            var end = (i == threadsNumber - 1) ? stepCount : start + stepCountPerThread;

            double localSum = 0;

            for (var j = start; j < end; j++)
            {
                var x1 = a + j * step;
                var x2 = x1 + step;
                localSum += (function(x1) + function(x2)) * (x2 - x1) / 2.0;
            }

            lock (locker)
                result += localSum;
        });

        return result;
    }
    
    public static double Solve(double a, double b, Func<double, double> function, double step)
    {
        var result = 0d;

        var stepCount = (b - a) / step;

        for (var i = 0; i < stepCount; i++)
        {
            var x1 = a + i * step;
            var x2 = x1 + step;
            result += (function(x1) + function(x2)) * (x2 - x1) / 2d;
        }

        return result;
    }
}
