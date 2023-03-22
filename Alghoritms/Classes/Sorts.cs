namespace Alghoritms.Classes;

public static class Sorts
{
    /// <summary>
    /// This private summarized method needs for some algs.
    /// It swaps values with using references.
    /// </summary>
    /// <param name="arg0">The first argument</param>
    /// <param name="arg1">The second argument</param>
    /// <typeparam name="T">Any type of parameter</typeparam>
    private static void Swap<T>(ref T arg0, ref T arg1)
        => (arg0, arg1) = (arg1, arg0);


    #region CountingSort

    /// <summary>
    /// Counting sorting can ONLY be used for arrays whose elements are numbers, like 0, 1, 2, 3 ... 9.
    /// The complexity of the algorithm is O(N), that is, it is very fast, but it pays for this with its narrow use.
    /// </summary>
    /// <param name="array">Source unsorted array</param>
    /// <returns>null, if array contains incorrect numbers</returns>
    /// <returns>Sorted integer array</returns>
    public static int[]? CountingSort(int[] array)
    {
        if (array.Length <= 1)
            return array;

        //When we count complexity of alghoritm, we do not take into account the cycle of value checking.
        for (int i = 0; i < array.Length; ++i)
            if (array[i] < 0 || array[i] > 9)
                return null;

        //ALG STARTS
        int[] result = new int [10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        for (int i = 0; i < array.Length; ++i)
            result[array[i]]++;

        int[] sortedArray = new int[array.Length];

        for (int i = 0, index = 0; i < 10; ++i)
        for (int n = 0; n < result[i]; ++n, ++index)
            sortedArray[index] = i;
        //ALG ENDS

        return sortedArray;
    }

    #endregion

    #region MergeSort

    /// <summary>
    /// It merges two sorted arrays in one
    /// </summary>
    /// <param name="arr0">First array</param>
    /// <param name="arr1">Second array</param>
    /// <returns>Merged integer array</returns>
    private static int[] Merge(int[] arr0, int[] arr1)
    {
        int[] resultArr = new int[arr0.Length + arr1.Length];
        int i = 0,
            j = 0;

        while (i < arr0.Length || j < arr1.Length)
            if (j == arr1.Length || i < arr0.Length && arr0[i] < arr1[j])
                resultArr[i + j] = arr0[i++];
            else
                resultArr[i + j] = arr1[j++];
        return resultArr;
    }

    /// <summary>
    /// Needs to divide array to two halves.
    /// </summary>
    /// <param name="array">Source array</param>
    /// <returns>Left half of integer array</returns>
    private static int[] GetLeftPart(int[] array)
    {
        int[] resultArray = new int[array.Length / 2];

        for (int i = 0; i < resultArray.Length; ++i)
            resultArray[i] = array[i];
        return resultArray;
    }

    /// <summary>
    /// Needs to divide array to two halves.
    /// </summary>
    /// <param name="array">Source array</param>
    /// <returns>Right half of integer array</returns>
    private static int[] GetRightPart(int[] array)
    {
        int[] resultArray;

        if (array.Length % 2 == 0)
        {
            resultArray = new int[array.Length - array.Length / 2];
            for (int i = 0; i < resultArray.Length; ++i)
                resultArray[i] = array[i + resultArray.Length];
        }

        else
        {
            resultArray = new int[array.Length - array.Length / 2];
            for (int i = 0; i < resultArray.Length; ++i)
                resultArray[i] = array[i + resultArray.Length - 1];
        }

        return resultArray;
    }

    /// <summary>
    /// The complexity of the algorithm is O(n log n).
    /// The algorithm is fast enough.
    /// </summary>
    /// <param name="array">Source unsorted array</param>
    /// <returns>Sorted integer array</returns>
    public static int[] MergeSort(int[] array)
    {
        if (array.Length <= 1)
            return array;

        int[] leftPart = GetLeftPart(array);
        int[] rightPart = GetRightPart(array);

        return Merge(MergeSort(leftPart), MergeSort(rightPart));
    }

    #endregion

    #region InsertionSort

    /// <summary>
    /// The complexity of the algorithm is estimated by O(n^2).
    /// </summary>
    /// <param name="array">Source array</param>
    /// <returns>Sorted integer array</returns>
    public static int[] InsertionSort(int[] array)
    {
        if (array.Length <= 1)
            return array;

        int[] resultArray = array;
        for (int i = 0, j; i < array.Length; ++i)
        {
            j = i;
            while (j > 0 && array[j] < array[j - 1])
            {
                Swap(ref array[j], ref array[j - 1]);
                j--;
            }
        }

        return resultArray;
    }

    #endregion

    #region Heapsort

    /// <summary>
    /// Heap insert inserts element in array (Sift up method)
    /// </summary>
    /// <param name="array">Array to insert</param>
    /// <param name="element">Element to insert</param>
    /// <returns>Sift up array with inserted element</returns>
    private static void InsertHeap(ref int[] array, int element)
    {
        if (array == Array.Empty<int>())
        {
            array = new int[] { element };
            return;
        }

        int[] result = new int[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
            result[i] = array[i];
        result[^1] = element;

        array = new int[result.Length];
        for (int i = 0; i < array.Length; ++i)
            array[i] = result[i];

        int n = array.Length - 1;
        int el = array[(n - 1) / 2];
        while (n > 0 && array[n] < array[(n - 1) / 2]) //Named "Sift up"
        {
            Swap(ref array[n], ref array[(n - 1) / 2]);
            n = (n - 1) / 2;
        }
    }

    /// <summary>
    /// Heap remove min element in array (Sift down method)
    /// </summary>
    /// <param name="array">Source Array</param>
    /// <returns>Removed min element sift down array</returns>
    private static void RemoveMinHeap(ref int[] array)
    {
        if (array == Array.Empty<int>())
            return;

        Swap(ref array[0], ref array[^1]);

        int[] result = new int[array.Length - 1];

        int? min = array.Min();
        for (int n = 0, idx = 0; n < array.Length; n++)
            if (min != null && array[n] == min)
            {
                min = null;
                continue;
            }
            else
                result[idx++] = array[n];


        array = new int[result.Length];
        for (int n = 0; n < result.Length; n++)
            array[n] = result[n];

        int i = 0;
        while (2 * i + 1 < array.Length) // Named "Sift down"
        {
            int j = 2 * i + 1;
            int TWO = 2 * i + 2;
            if (2 * i + 2 < array.Length && array[2 * i + 2] <= array[j])
                j = 2 * i + 2;
            if (array[i] > array[j])
                break;
            else
            {
                Swap(ref array[i], ref array[j]);
                i = j;
            }
        }

        array = array.Reverse().ToArray();
    }

    /// <summary>
    /// Binary tree (like binary heap).
    /// The complexity of the algorithm is O(n log n).
    /// </summary>
    /// <param name="array">Source array</param>
    /// <returns>Sorted integer array</returns>
    public static int[] Heapsort(int[] array)
    {
        // Parent index is ((i - 1) / 2)
        // Left child index is (2 * i + 1)
        // Right child index is (2 * i + 2)

        if (array.Length <= 1)
            return array;

        int[] heap = Array.Empty<int>();

        for (int i = 0; i < array.Length; ++i)
            InsertHeap(ref heap, array[i]);

        for (int i = 0; i < array.Length; ++i)
        {
            array[i] = heap.Min();
            RemoveMinHeap(ref heap);
        }

        return array;
    }

    #endregion

    #region BubbleSort

    /// <summary>
    /// Bubble sort is very simple alg.
    /// The complexity of the algorithm is O(n^2).
    /// </summary>
    /// <param name="array">Source array</param>
    /// <returns>Sorted integer array</returns>
    public static int[] BubbleSort(int[] array)
    {
        if (array.Length <= 1)
            return array;
        
        bool isSwapped;
        do
        {
            isSwapped = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    Swap(ref array[i], ref array[i + 1]);
                    isSwapped = true;
                }
            }
        } while (isSwapped);
        
        return array;
    }

    #endregion
}