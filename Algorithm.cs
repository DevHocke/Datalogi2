namespace Datalogi2
{
    static class Algorithm
    {
        /// <summary>
        /// An extention method that sorts the array in reversed order using insertion sort.
        /// The algorithm compares each element 'j' with element 'j - 1'. If element 'j' is
        /// greater the elements are swapped. It has a time complexity in the worst case of
        /// O(n^2) but it is a very fast algorithm when there are few elements to sort.
        /// </summary>
        /// <param name="arr">The array to sort.</param>
        public static void ReversedInsertionSort(this string[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var j = i;
                while (j > 0)
                {
                    // Finds the numbers which are the first 'words' in every result.
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

        /// <summary>
        /// Changes place of position i and j in the array.
        /// </summary>
        /// <param name="arr">The array to swap places in.</param>
        /// <param name="i">An index in the array.</param>
        /// <param name="j">An index in the array.</param>
        private static void Swap(string[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        /// <summary>
        /// Iterates over the array and puts all the words smaller
        /// then the pivot to the left of the pivot.
        /// </summary>
        /// <param name="arr">The array to iterate over.</param>
        /// <param name="left">Starting index.</param>
        /// <param name="right">The right boundery of the array
        /// and also the pivot element.</param>
        /// <returns>The index position of the pivot in the array.</returns>
        private static int Partition(string[] arr, int left, int right)
        {
            var i = left;
            var pivot = arr[right];

            for (int j = left; j < right; j++)
            {
                if (string.Compare(arr[j], pivot) < 0)
                {
                    Swap(arr, i, j);
                    i++;
                }
            }

            Swap(arr, i, right);
            return i;
        }

        /// <summary>
        /// Sorts the array using divide and conquer we used recurtion
        /// here because it is very effictive instead of a while loop and
        /// is easier to read.
        /// It has a time complexity in the best and average case of O(n log n)
        /// and in the worst case O(n^2).
        /// </summary>
        /// <param name="arr">The array to sort.</param>
        /// <param name="left">The left boundery to sort from.</param>
        /// <param name="right">The right boundery to sort up to.</param>
        private static void Quicksort(string[] arr, int left, int right)
        {
            if (left < right)
            {
                var pivot = Partition(arr, left, right);
                Quicksort(arr, left, pivot - 1);
                Quicksort(arr, pivot + 1, right);
            }
        }

        /// <summary>
        /// An extention method that sorts the array using quick sort.
        /// </summary>
        /// <param name="arr">The array to sort.</param>
        public static void Quicksort(this string[] arr)
        {
            Quicksort(arr, 0, arr.Length - 1);
        }
    }
}




