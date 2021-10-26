using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Datalogi2
{
    class App
    {
        public const int Size = 3;
        static string[][] chapters = new string[Size][];
        bool isSorted = false;
        BinaryTree searches = new BinaryTree();
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
            var search = new Search(Color.Getinput().Trim());
            search.Results = GetResults(search.Word);
            search.Results.ReversedInsertionSort();
            search.Print();
            AddToBinaryTree(search);
            Thread.Sleep(2000);
        }

        public void TraverseBinaryTree()
        {
            searches.Traverse();
            Console.ReadLine();
        }

        public void PrintWordsAlphabetically()
        {
            Console.Write("\n\tHow many words do you want to print? ");
            if (int.TryParse(Color.Getinput(), out var choice))
            {
                for (int i = 0; i < chapters.Length; i++)
                {
                    if (!isSorted)
                    {
                        chapters[i].Quicksort();
                    }

                    Color.InBlue($"\n\tChapter {i + 1}");
             
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

                isSorted = true;
            }
            else
            {
                Color.InRed("\n\tWrong type of input, Please try again. . .");
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

        private void AddToBinaryTree(Search search)
        {
            Console.Write($"\n\tDo you want to save the search to the binary tree (y/n): ");
            var choice = Console.ReadLine();
            if (choice.Trim().ToLower() == "y")
            {
                searches.Add(search);
                Color.InGreen("\tThe search was saved to the binary tree.");
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
    }
}
