using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Datalogi2
{
    class App
    {
        public const int Size = 3;
        static string[][] chapters = new string[Size][];
        static List<Search> searches = new List<Search>();
        public void Start()
        {
            for (int i = 0; i < Size; i++)
            {
                chapters[i] = TurnChapterToArray(GetChapter($"Chapter_{i + 1}.txt"));
            }

            Menu.MainMenu();
        }

        public static string GetChapter(string fileName)
        {
            return File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
        }

        /// <summary>
        /// Takes a string and removes characters that are not letters and stores it in an array.
        /// </summary>
        /// <param name="chapter">The chapter that will be turned into an array.</param>
        /// <returns>An array of words without unwanted characters.</returns>
        public static string[] TurnChapterToArray(string chapter)
        {
            chapter = Regex.Replace(chapter, @"[^\w\s]", "");
            chapter = Regex.Replace(chapter, @"\s+", " ");
            return chapter.Split(" ");
        }

        public static void SearchForAWord()
        {
            Console.Write("\n\tEnter a word to search for: ");
            var search = new Search(Console.ReadLine().Trim().ToLower());
            search.Results = ReversedBubbleSort(GetResults(search.Word));
            Print(search.Results, $"\n\tThe word '{search.Word}' was found:");
            DoYouWantToSave(search);
            Thread.Sleep(2000);
        }

        private static void DoYouWantToSave(Search search)
        {
            Console.WriteLine($"\n\tDo you want to save the search to the data structure (y/n): ");
            var choice = Console.ReadLine();
            if (choice.Trim().ToLower() == "y")
            {
                searches.Add(search);
                Console.WriteLine("\n\tThe search was saved to the data structure");
            }
        }

        private static string[] ReversedBubbleSort(string[] results)
        {
            for (int i = 0; i < results.Length - 1; i++)
            {
                var swapped = false;
                for (int j = 0; j < results.Length - i - 1; j++)
                {
                    int.TryParse(results[j].Substring(0, results[j].IndexOf(' ')), out var val1);
                    int.TryParse(results[j + 1].Substring(0, results[j + 1].IndexOf(' ')), out var val2);
                    if (val1 < val2)
                    {
                        var tmp = results[j];
                        results[j] = results[j + 1];
                        results[j + 1] = tmp;
                    }
                }
                if (!swapped)
                    break;

            }
            return results;
        }

        private static string[] GetResults(string search)
        {
            var results = new string[Size];
            for (int i = 0; i < chapters.Length; i++)
            {
                var counter = 0;
                foreach (var word in chapters[i])
                {
                    if (word == search)
                    {
                        counter++;
                    }
                }

                var times = counter != 1 ? "times" : "time";
                results[i] = $"\t{counter} {times} in chapter {i + 1}";
            }

            return results;
        }

        private static void Print(string[] arr, string message = "")
        {
            Console.WriteLine(message);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
