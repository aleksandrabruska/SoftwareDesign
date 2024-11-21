using Pipelines;
using StringCompression;
using System.Diagnostics;

class Program
{
    public static void Main()
    {
        Stopwatch sw = new Stopwatch();

        SequentialStringCompression ssc = new SequentialStringCompression("abc",5000 , 6000);
        
        sw.Start();
        double ratio = ssc.Run();
        sw.Stop();
        Console.WriteLine("Sequential time " + sw.ElapsedMilliseconds);
        //Console.WriteLine(ratio);
        sw.Reset();


        PipelinesStringCompression psc = new PipelinesStringCompression("abc", 5000, 6000);

        sw.Start();
        psc.Run();
        sw.Stop();
        Console.WriteLine("Pipelines time " + sw.ElapsedMilliseconds);
    }
}