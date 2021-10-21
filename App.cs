using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Datalogi2
{
    class App
    {
        static string[][] chapters = new string[3][];
        public void Start()
        {
            chapters[0] = TurnChapterToArray(GetChapter("Chapter_1.txt"));
            chapters[1] = TurnChapterToArray(GetChapter("Chapter_2.txt"));
            chapters[2] = TurnChapterToArray(GetChapter("Chapter_3.txt"));

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
            
            


           
            Console.ReadKey();
        }
    }
}
