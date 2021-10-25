namespace Datalogi2
{
    static class Algoritm
    {
        /// <summary>
        /// Compares each result j with result j - 1. If result j is greater the results are swapped.
        /// Worst case O(n^2) but is very fast on small arrays. 
        /// </summary>
        /// <param name="arr">The array to sort.</param>
        public static void ReversedInsertionSort(this string[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var j = i;
                while (j > 0)
                {
                    int.TryParse(arr[j - 1].Substring(0, arr[j - 1].IndexOf(' ')), out var val1);
                    int.TryParse(arr[j].Substring(0, arr[j].IndexOf(' ')), out var val2);
                    if (val1 < val2)
                    {
                        Swap(arr, j, j - 1);
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void Swap(string[] arr,int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
