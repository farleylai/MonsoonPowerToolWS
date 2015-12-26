using System;

namespace Sort
{
    public static class Sort
    {
        #region Delegates
        // caller-supplied callback functions
        public delegate int CompareFunc(int i, int j);
        public delegate void SwapFunc(int i, int j);
        #endregion Delegates

        #region Methods

        #region QuickSort
        private static int quickSortPartition(CompareFunc compare, SwapFunc swap, int low, int high)
        {
            int pivot = low, m = low, n = high + 1;

            while (m < high && compare(++m, pivot) <= 0) // find first larger element
                ;
            while (compare(--n, pivot) > 0) // find last smaller element
                ;

            //loop until the indices cross
            while (m < n)
            {
                // swap
                swap(m, n);

                // find next values to swap
                while (compare(pivot, ++m) > 0)
                    ;
                while (compare(--n, pivot) > 0)
                    ;
            }

            swap(n, low); // swap beginning with n

            return n; // n is now the division between two unsorted halves
        }

        public static void QuickSort(CompareFunc compare, SwapFunc swap, int low, int high)
        {
            if (low < high)
            {
                int part = quickSortPartition(compare, swap, low, high);

                QuickSort(compare, swap, low, part - 1);
                QuickSort(compare, swap, part + 1, high);
            }
        }

        public static void QuickSort(CompareFunc compare, SwapFunc swap, int count)
        {
            if (count > 1)
                QuickSort(compare, swap, 0, count - 1);
        }

        #endregion QuickSort

        #region BubbleSort
        public static void BubbleSort(CompareFunc compare, SwapFunc swap, int count)
        {
            if (count > 1)
                BubbleSort(compare, swap, 0, count - 1);
        }

        public static void BubbleSort(CompareFunc compare, SwapFunc swap, int low, int high)
        {
            for (int left = low; left < high; left++)
                for (int right = left + 1; right <= high; right++)
                    if (compare(left, right) > 0)
                        swap(left, right);
        }

        #endregion BubbleSort

        #region HeapSort
        public static void HeapSort(CompareFunc compare, SwapFunc swap, int count)
        {
            if (count > 1)
                HeapSort(compare, swap, 0, count - 1);
        }

        public static void HeapSort(CompareFunc compare, SwapFunc swap, int low, int high) 
        {
           heapify(compare, swap, low, high);
           for (int end = high; end > low; )
           {
               swap(low, end--);
               siftDown(compare, swap, low, end);
           }
        }

        private static void heapify(CompareFunc compare, SwapFunc swap, int low, int high) 
        {
           int count = high - low + 1;
           for (int start = low + count / 2 - 1; start >= low; start--)
               siftDown(compare, swap, start, high);
        }

        private static void siftDown(CompareFunc compare, SwapFunc swap, int start, int end) 
        {
           int root = start;

           for (int child = root * 2 + 1; child <= end; child = root * 2 + 1)
           {
               if (child < end && compare(child, child+1) < 0)
                   child++;

               if (compare(root, child) < 0)
               {
                   swap(root, child);
                   root = child;
               }
               else
               {
                   return;
               }
           }
        }
        #endregion HeapSort

        #region GnomeSort
        // at last check, loops infinitely for reverse-sorted data... use with caution
        public static void GnomeSort(CompareFunc compare, SwapFunc swap, int count)
        {
            if (count >  1)
                GnomeSort(compare, swap, 0, count - 1);
        }

        public static void GnomeSort(CompareFunc compare, SwapFunc swap, int low, int high)
        {
            for (int i = low+1, j = low+2; i <= high; )
            {
                if (i == low || compare(i, i-1) > 0)
                {
                    i = j++;
                }
                else
                {
                    swap(i, i - 1);
                    i = Math.Max(low + 1, i - 1);
                }
            }
        }
        #endregion GnomeSort

        #region ShellSort
        public static void ShellSort(CompareFunc compare, SwapFunc swap, int count)
        {
            ShellSort(compare, swap, 0, count - 1);
        }

        public static void ShellSort(CompareFunc compare, SwapFunc swap, int low, int high)
        {
            int count = high - low + 1;
            for (int inc = count / 2; inc > 0; inc = (inc == 2) ? 1 : (int)Math.Round(inc / 2.2))
                for (int i = low + inc; i < high+1; i++)
                    for (int j = i; j >= inc && compare(j - inc, j) > 0; j -= inc)
                        swap(j, j - inc);
        }
        #endregion ShellSort

        #region CombSort
        public static void CombSort(CompareFunc compare, SwapFunc swap, int count)
        {
            CombSort(compare, swap, 0, count - 1);
        }

        public static void CombSort(CompareFunc compare, SwapFunc swap, int low, int high)
        {
            // a.k.a. Dobosiewicz Sort
            int gap = high - low + 1;
            int swaps = 0;

            do
            {
                gap = Math.Max(1, (10 * gap + 3) / 13);
                if (gap == 9 || gap == 10)
                    gap = 11;

                swaps = 0;

                for (int left = low; left < high + 1 - gap; left++)
                {
                    int right = left + gap;
                    if (compare(left, right) > 0)
                    {
                        swap(left, right);
                        swaps++;
                    }
                }
            } while (gap > 1 || swaps > 0);
        }
        #endregion CombSort

        #region CocktailSort
        public static void CocktailSort(CompareFunc compare, SwapFunc swap, int low, int high)
        {
            // a.k.a. Bidirectional Bubble sort
            for (int bottom = low, top = high, swaps = 1; swaps > 0; bottom++)
            {
                swaps = 0;

                for (int i = bottom; i < top; i++)
                {
                    if (compare(i, i + 1) > 0)
                    {
                        swap(i, i + 1);
                        swaps++;
                    }
                }

                top--;
                if (swaps > 0)
                {
                    for (int i = top; i > bottom; i--)
                    {
                        if (compare(i, i - 1) < 0)
                        {
                            swap(i, i - 1);
                            swaps++;
                        }
                    }
                }
            }
        }

        public static void CocktailSort(CompareFunc compare, SwapFunc swap, int count)
        {
            if (count > 1)
                CocktailSort(compare, swap, 0, count - 1);
        }

        #endregion CocktailSort        

        #region SelectionSort
        public static void SelectionSort(CompareFunc compare, SwapFunc swap, int count)
        {
            if (count > 1)
                SelectionSort(compare, swap, 0, count - 1);
        }

        public static void SelectionSort(CompareFunc compare, SwapFunc swap, int low, int high)
        {
            for (int left = low; left < high; left++)
            {
                int min = left;
                for (int right = left + 1; right <= high; right++)
                    if (compare(min, right) > 0)
                        min = right;
                if (left != min)
                    swap(left, min);
            }
        }
        #endregion SelectionSort

        #region IntroSort
        public static void IntroSort(CompareFunc compare, SwapFunc swap, int count)
        {
            if (count > 1)
                IntroSort(compare, swap, 0, count - 1);
        }

        public static void IntroSort(CompareFunc compare, SwapFunc swap, int low, int high)
        {
            int count = high - low + 1;
            introSort(compare, swap, low, high, (int)Math.Floor(2.5 * Math.Log(count, 2)));
        }

        private static void introSort(CompareFunc compare, SwapFunc swap, int low, int high, int maxDepth)
        {
            if (low < high)
            {
                if (maxDepth-- <= 0)
                {
                    HeapSort(compare, swap, low, high);
                }
                else if (high - low < 8)
                {
                    InsertionSort(compare, swap, low, high);
                }
                else
                {
                    int part = quickSortPartition(compare, swap, low, high);

                    introSort(compare, swap, low,    part-1, maxDepth);
                    introSort(compare, swap, part+1, high,   maxDepth);
                }
            }
        }
        #endregion IntroSort

        #region ShakerSort
        public static void ShakerSort(CompareFunc compare, SwapFunc swap, int count)
        {
            if (count > 1)
                ShakerSort(compare, swap, 0, count - 1);
        }

        public static void ShakerSort(CompareFunc compare, SwapFunc swap, int low, int high)
        {
            for (int i = low, k = high; i < k; i++, k--)
            {
                int min = i, max = i;
                for (int j = i + 1; j <= k; j++)
                {
                    if (compare(j, min) < 0)
                        min = j;
                    if (compare(j, max) > 0)
                        max = j;
                }

                swap(i, min);

                if (max == i)
                    swap(k, min);
                else
                    swap(k, max);
            }
        }
        #endregion ShakerSort

        #region InsertionSort
        public static void InsertionSort(CompareFunc compare, SwapFunc swap, int count)
        {
            if (count >  1)
                InsertionSort(compare, swap, 0, count - 1);
        }

        public static void InsertionSort(CompareFunc compare, SwapFunc swap, int low, int high)
        {
            for (int i = low+1; i <= high; i++)
                for (int j = i; j > low && compare(j-1, j) > 0; j--)
                     swap(j-1, j);
        }
        #endregion InsertionSort

        #region InOrder
        public static bool InOrder(CompareFunc compare, int low, int high)
        {
            for (int i = low; i < high; )
                if (compare(i, ++i) > 0)
                    return false;
            return true;
        }

        public static bool InOrder(CompareFunc compare, int count)
        {
            bool result = true;

            if (count > 1)
                result = InOrder(compare, 0, count - 1);

            return result;
        }
        #endregion InOrder

        #region Debug code
#if DEBUG

        public delegate void SortFunc(CompareFunc compare, SwapFunc swap, int count);

        private static int[] testArray = new int[10000];
        private static int swaps = 0;
        private static int compares = 0;

        private static void swap(int i, int j)
        {
            swaps++;

            if (i != j)
            {
                int temp = testArray[i];
                testArray[i] = testArray[j];
                testArray[j] = temp;
            }
        }

        private static int compare(int i, int j)
        {
            compares++;
            int result = testArray[i] - testArray[j];

            // In case of a tie, do a secondary comparison based on the indices
            // This yields a stable sort, no matter which sort algorithm is in use.
            if (result == 0)
                result = i - j;

            return result;
        }

        private static void reset()
        {
            swaps = compares = 0;
        }

        private static void randomize()
        {
            Random rand = new Random();
            for (int i = 0; i < testArray.Length; i++ )
                testArray[i] = rand.Next(testArray.Length);
        }

        private static void reverse(int[] array)
        {
            int i = 0, j = array.Length - 1;
            while (i < j)
                swap(i++, j--);
        }

        private static int checksum()
        {
            int result = 0;
            foreach (int x in testArray)
                result += x;
            return result;
        }

        public static bool Test()
        {
            bool result = true;

            SortFunc[] sortFunc = new SortFunc[] {GnomeSort, QuickSort, BubbleSort, HeapSort, 
                                                  ShellSort, InsertionSort, ShakerSort,
                                                  CombSort, CocktailSort, SelectionSort, IntroSort};

            long[] rand_swap = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
            long[] rand_comp = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
            long[] sorted_swap = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
            long[] sorted_comp = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
            long[] rev_swap = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
            long[] rev_comp = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };

            const int trials=10;

            for (int trial=0; trial < trials; trial++)
            {
                for (int algo = 0; algo < sortFunc.Length; algo++)
                {
                    // sort random array
                    reset();
                    randomize();
                    int sum = checksum();
                    sortFunc[algo](compare, swap, testArray.Length);
                    result = sum == checksum() && InOrder(compare, testArray.Length);

                    rand_comp[algo] += compares;
                    rand_swap[algo] += swaps;

                    // sort sorted array
                    reset();
                    sortFunc[algo](compare, swap, testArray.Length);

                    sorted_comp[algo] += compares;
                    sorted_swap[algo] += swaps;

                    // sort reverse sorted array
                    reset();
                    reverse(testArray);
                    sortFunc[algo](compare, swap, testArray.Length);

                    rev_comp[algo] += compares;
                    rev_swap[algo] += swaps;
                }
            }

            for (int algo = 0; algo < sortFunc.Length; algo++)
            {
                rand_comp[algo] /= trials;
                rand_swap[algo] /= trials;

                sorted_comp[algo] /= trials;
                sorted_swap[algo] /= trials;

                rev_comp[algo] /= trials;
                rev_swap[algo] /= trials;
            }

            return result;
        }
#endif
        #endregion Debug code

        #endregion Methods
    }
}
