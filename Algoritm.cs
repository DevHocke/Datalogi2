using System;
using System.Collections.Generic;
using System.Text;

namespace Datalogi2
{
    static class Algoritm
    {
        /// <summary>
        /// Compares each result j with result j - 1. If result j is greater the results are swapped.
        /// Worst case O(n^2) but is very fast on small arrays. 
        /// </summary>
        /// <param name="results">The array to sort.</param>
        public static void ReversedInsertionSort(this string[] results)
        {
            for (int i = 1; i < results.Length; i++)
            {
                var j = i;
                while (j > 0)
                {
                    int.TryParse(results[j - 1].Substring(0, results[j - 1].IndexOf(' ')), out var val1);
                    int.TryParse(results[j].Substring(0, results[j].IndexOf(' ')), out var val2);
                    if (val1 < val2)
                    {
                        var tmp = results[j];
                        results[j] = results[j - 1];
                        results[j - 1] = tmp;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
