using System;
using System.Diagnostics;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            GameOfLife gol = new GameOfLife(100);

            /*stopwatch.Start();
            gol.Run(1000);
            stopwatch.Stop();
            Console.WriteLine("Serial time " + stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            stopwatch.Start();
            gol.RunParallel(1000);
            stopwatch.Stop();
            Console.WriteLine("Parallel time " + stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            */
            stopwatch.Start();
            gol.RunWithBarrier(1000);
            stopwatch.Stop();
            Console.WriteLine("Barrier time " + stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();


        }
    }
}
