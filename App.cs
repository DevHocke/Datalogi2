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
        Dictionary<string, string[]> searches = new Dictionary<string, string[]>();
        public void Start()
        {
            Menu menu = new Menu();
            for (int i = 0; i < Size; i++)
            {
                chapters[i] = TurnChapterToArray(GetChapter($"Chapter_{i + 1}.txt"));
            }

            menu.MainMenu();
        }

        public void SearchForAWord()
        {
            Console.Write("\n\tEnter a word to search for: ");
            var search = new Search(Console.ReadLine().Trim().ToLower());
            search.Results = GetResults(search.Word);
            search.Results.ReversedInsertionSort();
            Print(search.Results, $"\n\tThe word '{search.Word}' was found:");
            DoYouWantToSave(search);
            Thread.Sleep(2000);
        }

        public void PrintDataStructure()
        {
            var ctr = 1;
            foreach (var search in searches)
            {
                Console.WriteLine($"\n\t{ctr++}. {search.Key} was found:");
                foreach (var result in search.Value)
                {
                    Console.WriteLine(result);
                }
            }

            Console.ReadLine();
        }

        public void PrintWordsAlphabetically()
        {
            Console.Write("\n\tHow many words do you want to print? ");
            if (int.TryParse(Console.ReadLine(), out var choice))
            {
                for (int i = 0; i < chapters.Length; i++)
                {
                    Array.Sort(chapters[i]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\n\tChapter {i + 1}");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < choice; j++)
                    {
                        if (j % 10 == 0)
                        {
                            Console.Write("\n\t");
                        }

                        if (j < chapters[i].Length)
                        {
                            Console.Write(chapters[i][j] + " ");
                        }
                        else
                        {
                            break;
                        }
                    }

                   Console.WriteLine();
                }
            }

            Console.ReadKey();
        }

        private string GetChapter(string fileName)
        {
            return File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
        }

        /// <summary>
        /// Takes a string and removes characters that are not letters and stores it in an array.
        /// </summary>
        /// <param name="chapter">The chapter that will be turned into an array.</param>
        /// <returns>An array of words without unwanted characters.</returns>
        private string[] TurnChapterToArray(string chapter)
        {
            chapter = Regex.Replace(chapter, @"[^\w\s]", "");
            chapter = Regex.Replace(chapter, @"\s+", " ");
            return chapter.Split(" ");
        }

        private void DoYouWantToSave(Search search)
        {
            Console.WriteLine($"\n\tDo you want to save the search to the data structure (y/n): ");
            var choice = Console.ReadLine();
            if (choice.Trim().ToLower() == "y")
            {
                try
                {
                    searches.Add(search.Word, search.Results);
                    Console.WriteLine("\tThe search was saved to the data structure");
                }
                catch
                {
                    Console.WriteLine("\tThe search already exists in the data structure");
                }
            }
        }

        /// <summary>
        /// Hello.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        private string[] GetResults(string search)
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

        private void Print(string[] arr, string message = "")
        {
            Console.WriteLine(message);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
