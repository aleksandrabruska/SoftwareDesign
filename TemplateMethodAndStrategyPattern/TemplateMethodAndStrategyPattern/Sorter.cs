using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodAndStrategyPattern
{
    internal abstract class Sorter
    {
        protected IGenerator generator;

        public void SetGenerator(IGenerator _generator)
        {
            this.generator = _generator;
        }

        protected int[] Generate(uint size, int seed)
        {
            return this.generator.generate(size, seed);
        }

        protected abstract int[] MySort(int[] data);
        
        public int[] PerformSort()
        {
            int[] array = Generate(100, 42);
            int[] returnArray = MySort(array);
            return returnArray;
        }

        public static void exchange(int[] data, int m, int n)
        {
            int temporary;

            temporary = data[m];
            data[m] = data[n];
            data[n] = temporary;
        }

    }
}
