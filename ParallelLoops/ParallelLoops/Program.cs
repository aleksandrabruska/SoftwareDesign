using ParallelLoops;
using System.Diagnostics;
public struct abc {
    public double A;
    public double B;
    public double C;
}
class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        const int N = 80000000;
        double[] A, B, C;
        A = new double[N];
        B = new double[N];
        C = new double[N];

        Random rand = new Random();
        for (int i = 0; i < N; i++)
        {
            A[i] = rand.Next();
            B[i] = rand.Next();
            C[i] = rand.Next();
        }

        Console.WriteLine("Starts sequential for now.");
        stopwatch.Start();
        for (int i = 0; i < N; i++)
        {
            C[i] = A[i] * B[i] - A[i] * B[i] + A[i] + A[i] * B[i] - A[i] / A[i] + A[i] / B[i];
            C[i] = A[i] * B[i] - A[i] * B[i] + A[i];
            C[i] = A[i] * B[i] - A[i] + 1 - 3 + A[i] / B[i];
            C[i] = A[i] * B[i] - A[i] * B[i] + A[i];
        }
        stopwatch.Stop();
        Console.WriteLine("Sequential loop time in milliseconds: {0}",
                          stopwatch.ElapsedMilliseconds);
        stopwatch.Reset();

        stopwatch.Start();
        NaiveParallelFor.MyParallelFor(0, N, i =>
        {
            C[i] = A[i] * B[i] - A[i] * B[i] + A[i] + A[i] * B[i] - A[i] / A[i] + A[i] / B[i];
            C[i] = A[i] * B[i] - A[i] * B[i] + A[i];
            C[i] = A[i] * B[i] - A[i] + 1 - 3 + A[i] / B[i];
            C[i] = A[i] * B[i] - A[i] * B[i] + A[i];
        });
        stopwatch.Stop();
        Console.WriteLine("Naive parallel loop time in milliseconds: {0}",
                  stopwatch.ElapsedMilliseconds);
        stopwatch.Reset();

        stopwatch.Start();
        Parallel.For(0, N, i =>
        {
            C[i] = A[i] * B[i] - A[i] * B[i] + A[i] + A[i] * B[i] - A[i] / A[i] + A[i] / B[i];
            C[i] = A[i] * B[i] - A[i] * B[i] + A[i];
            C[i] = A[i] * B[i] - A[i] + 1 - 3 + A[i] / B[i];
            C[i] = A[i] * B[i] - A[i] * B[i] + A[i];
        });
        stopwatch.Stop();
        Console.WriteLine("Parallel.for loop time in milliseconds: {0}",
                  stopwatch.ElapsedMilliseconds);
        stopwatch.Reset();

        abc[] array = new abc[N];
        for(int i = 0; i < N; i++)
        {
            array[i].A = A[i];
            array[i].B = B[i];
            array[i].C = C[i];
        }

        stopwatch.Start();
        Parallel.ForEach(array, arg =>
            {
                arg.C = arg.A * arg.B - arg.A * arg.B + arg.A + arg.A * arg.B - arg.A / arg.A + arg.A / arg.B;
                arg.C = arg.A * arg.B - arg.A * arg.B + arg.A;
                arg.C = arg.A * arg.B - arg.A + 1 - 3 + arg.A / arg.B;
                arg.C = arg.A * arg.B - arg.A * arg.B + arg.A;

            });
        stopwatch.Stop();
        Console.WriteLine("Parallel.ForEach loop time in milliseconds: {0}",
                  stopwatch.ElapsedMilliseconds);
        stopwatch.Reset();
        Console.WriteLine("Finished");
    }
}