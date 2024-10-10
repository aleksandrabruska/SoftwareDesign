using System.ComponentModel.DataAnnotations;
using TemplateMethodAndStrategyPattern;

class MainClass
{
    private static void display(int[] result)
    {
        foreach (int i in result)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        Console.WriteLine();

    }
    public static void Main(String[] args)
    {
        IGenerator gen1 = new RandomGenerator();
        int[] result = gen1.generate(25, 1234);
        display(result);
        IGenerator gen2 = new NearlySortedGenerator();
        result = gen2.generate(25, 1234);
        display(result);
        IGenerator gen3 = new ReverseOrder();
        result = gen3.generate(25, 1234);
        display(result);
        IGenerator gen4 = new FewUniqueGenerator();
        result = gen4.generate(25, 1234);
        display(result);
    }

    
}

