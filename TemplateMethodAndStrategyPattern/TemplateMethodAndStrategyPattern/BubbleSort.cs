using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodAndStrategyPattern
{
    internal class BubbleSort : Sorter
    {

        protected override int[] MySort(int[] data)
        {
            int i, j;
            int N = data.Length;

            for (j = N - 1; j > 0; j--)
            {
                for (i = 0; i < j; i++)
                {
                    if (data[i] > data[i + 1])
                        exchange(data, i, i + 1);
                }
            }

            return data;
        }
    }
}
