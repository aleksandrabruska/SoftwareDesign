using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodAndStrategyPattern
{
    internal class FewUniqueGenerator : IGenerator
    {
        public int[] generate(uint size, int seed)
        {
            Random random = new Random(seed);
            int UNIQUE_NUM = 10;
            int[] uniques = new int[UNIQUE_NUM];

            for(int i = 0; i < uniques.Length; i++)
            {
                uniques[i] = random.Next();
            }

            int[] res = new int[size];
            for(int i = 0; i < size; i++)
            {
                int uniqueIdx = random.Next(0,UNIQUE_NUM-1);
                res[i] = uniques[uniqueIdx];
            }
            return res;

        }
    }
}
