using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodAndStrategyPattern
{
    internal class InsertionSort : Sorter
    {
        protected override int[] MySort(int[] data)
        {
            int i, j;
            int N = data.Length;

            for (j = 1; j < N; j++)
            {
                for (i = j; i > 0 && data[i] < data[i - 1]; i--)
                {
                    exchange(data, i, i - 1);
                }
            }

            return data;
        }
    }
}
