using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodAndStrategyPattern
{
    internal class RandomGenerator: IGenerator
    {
        public int[] generate(uint size, int seed)
        {
            Random random = new Random(seed);
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = random.Next(1, 100);
            }
            return result;
        }
    }
}
