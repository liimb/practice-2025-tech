namespace task14;

public static class DefiniteIntegral
{
    public static double Solve(double a, double b, Func<double, double> function, double step, int threadsNumber)
    {
        var stepCount = (b - a) / step;

        var result = 0d;
        var locker = new object();

        var barrier = new Barrier(threadsNumber + 1);
        var threads = new Thread[threadsNumber];

        var stepsPerThread = stepCount / threadsNumber;
        var remainingSteps = stepCount % threadsNumber;

        var currentStartStep = 0d;

        for (var i = 0; i < threadsNumber; i++)
        {
            var localStartStep = currentStartStep;
            var localSteps = stepsPerThread + (i < remainingSteps ? 1 : 0);
            currentStartStep += localSteps;

            threads[i] = new Thread(() =>
            {
                var sum = 0d;

                for (var j = 0; j < localSteps; j++)
                {
                    var x1 = a + (localStartStep + j) * step;
                    var x2 = x1 + step;
                    sum += (function(x1) + function(x2)) * (x2 - x1) / 2d;
                }

                lock (locker)
                {
                    result += sum;
                }

                barrier.SignalAndWait();
            });

            threads[i].Start();
        }

        barrier.SignalAndWait();

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
