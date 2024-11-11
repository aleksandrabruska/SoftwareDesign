namespace QuickSort;

public class ParallelQuickSort
{
    public static void SortQuick(long[] elements, long left, long right)
    {
        long i = left, j = right;
        var pivot = elements[(left + right) / 2];

        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0) i++;
            while (elements[j].CompareTo(pivot) > 0) j--;

            if (i <= j)
            {
                // Swap
                var tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;

                i++;
                j--;
            }
        }

        Task t1;
        Task t2;
        // Recursive calls

        if (left < j && i < right)
        {
            t1 = Task.Run(() => SortQuick(elements, left, j));
            t2 = Task.Run(() => SortQuick(elements, i, right));
            Task.WaitAll(t1, t2);
        }

        else
        {
            if (left < j)
            {
                t1 = Task.Run(() => SortQuick(elements, left, j));
                //Task.WaitAll(t1);
            }

            if (i < right)
            {
                t2 = Task.Run(() => SortQuick(elements, i, right));
                //Task.WaitAll(t2);
            }
        }
        
        
    }

    public static bool checkSort(long[] elements)
    {
        var previous = elements[0];
        foreach (var element in elements)
        {
            if (previous > element)
                return false;
            previous = element;
        }

        return true;
    }
}