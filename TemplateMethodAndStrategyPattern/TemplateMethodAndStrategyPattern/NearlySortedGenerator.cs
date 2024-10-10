using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodAndStrategyPattern
{
    internal class NearlySortedGenerator : IGenerator
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
                    result[i] = random.Next(result[i-1], result[i-1] + 10);
                }
            }
            int CHANGES_NUM = 10;
            for(int i = 0; i< CHANGES_NUM; i++)
            {
                int idx1 = random.Next(0, (int)size-1);
                int idx2 = random.Next(0, (int)size-1);
                int temp = result[idx1];
                result[idx1] = result[idx2];
                result[idx2] = temp;
            }
            return result;
        }
    }
}
