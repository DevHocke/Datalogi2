using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Datalogi2
{
    class App
    {
        /// <summary>
        /// Determines the size of the chapters array and the search results array.
        /// </summary>
        public const int Size = 3;

        /// <summary>
        /// A multidimensional array of chapters.
        /// </summary>
        static string[][] chapters = new string[Size][];

        /// <summary>
        /// A flag to keep track if the chapters are sorted.
        /// </summary>
        bool isSorted = false;

        /// <summary>
        /// An abstract data structure with searches.
        /// </summary>
        BinaryTree searches = new BinaryTree();

        /// <summary>
        /// Starts the application by fetching each chapter and then calls on main menu.
        /// </summary>
        public void Start()
        {
            for (int i = 0; i < Size; i++)
            {
                chapters[i] = TurnChapterToArray(GetChapter($"Chapter_{i + 1}.txt"));
            }

            Menu menu = new Menu();
            menu.MainMenu();
        }

        /// <summary>
        /// Searches all the chapters for words that match the user input.
        /// Displays the results to the console and gives the user a option
        /// to save the result to the binary tree.
        /// </summary>
        public void SearchForAWord()
        {
            Console.Write("\n\tEnter a word to search for: ");
            var search = new Search(Color.Getinput().Trim());
            GetResults(search, Size - 1);
            search.Results.ReversedInsertionSort();
            search.Print();
            AddToBinaryTree(search);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Traverses to through the binary tree.
        /// </summary>
        public void TraverseBinaryTree()
        {
            searches.Traverse();
            Console.ReadLine();
        }

        /// <summary>
        /// Takes a user input on how many words to print and then prints them 
        /// to the console in alphabetical order.
        /// </summary>
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

        /// <summary>
        /// Gets the chapter as a string.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The text file as a string.</returns>
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

        /// <summary>
        /// Lets the user save the search to the binary tree.
        /// </summary>
        /// <param name="search">The search to save.</param>
        private void AddToBinaryTree(Search search)
        {
            Console.Write($"\n\tDo you want to save the search to the binary tree (y/n): ");
            var choice = Color.Getinput();
            if (choice.ToLower() == "y")
            {
                searches.Add(search);
                Color.InGreen("\tThe search was saved to the binary tree.");
            }
        }

        /// <summary>
        /// Iterates over all the chapters and gets a count on how many times
        /// the search word appears in every chapter.
        /// Recursion is used here to get rid of the loop, but it does not change the
        /// time complexity wich still is O(n). Together with the compare method the
        /// complete time complexity would be O(n^2).
        /// </summary>
        /// <param name="search">The search to compare.</param>
        /// <param name="chapterIndex">The index of each chapter.</param>
        private void GetResults(Search search, int chapterIndex)
        {
            if (chapterIndex < 0)
            {
                return;
            }

            var counter = Compare(search.Word, chapters[chapterIndex], chapters[chapterIndex].Length - 1);
            var times = counter != 1 ? "times" : "time";
            search.Results[chapterIndex] = $"\t{counter} {times} in chapter {chapterIndex + 1}";
            GetResults(search, chapterIndex - 1);
        }

        /// <summary>
        /// Compares a search word with every word in the given chapter.
        /// Recursion is used here to get rid of the loop, but it does not change the
        /// time complexity wich still is O(n).
        /// </summary>
        /// <param name="searchWord">The word to compare against.</param>
        /// <param name="chapter">A chapter with words to compare.</param>
        /// <param name="wordIndex">The index of a word in the chapter.</param>
        /// <returns>The amount of times the search word appears in the chapter.</returns>
        private int Compare(string searchWord, string[] chapter, int wordIndex)
        {
            if (wordIndex < 0)
            {
                return 0;
            }

            if (searchWord.ToLower() == chapter[wordIndex].ToLower())
            {
                return 1 + Compare(searchWord, chapter, wordIndex - 1);
            }

            return Compare(searchWord, chapter, wordIndex - 1);
        }
    }
}
