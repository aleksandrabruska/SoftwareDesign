using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodAndStrategyPattern
{
    internal class ReverseOrder : IGenerator
    {
        public int[] generate(uint size, int seed)
        {
            Random random = new Random(seed);
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                if (i == 0)
                {
                    result[i] = random.Next();
                }
                else
                {
                    result[i] = random.Next(result[i - 1]);
                }
            }
          
            return result;
        }
    }
}
