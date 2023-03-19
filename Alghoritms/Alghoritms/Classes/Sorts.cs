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


    #region SortByCounting

    /// <summary>
    /// Counting sorting can ONLY be used for arrays whose elements are numbers, like 0, 1, 2, 3 ... 9.
    /// The complexity of the algorithm is O(N), that is, it is very fast, but it pays for this with its narrow use.
    /// </summary>
    /// <param name="array">Source unsorted array</param>
    /// <returns>null, if array contains incorrect numbers</returns>
    /// <returns>sorted integer array</returns>
    public static int[]? SortByCounting(int[] array)
    {
        if (array.Length == 0)
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
}