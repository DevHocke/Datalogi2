using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Datalogi2
{
    class App
    {
        static string[][] textFiles = new string[3][];
        public void Start()
        {
            textFiles[0] = TurnTextFileToArray(GetTextFile("Text_1.txt"));
            textFiles[1] = TurnTextFileToArray(GetTextFile("Text_2.txt"));
            textFiles[2] = TurnTextFileToArray(GetTextFile("Text_3.txt"));

            Menu.MainMenu();
        }

        public static string GetTextFile(string fileName)
        {
            return File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
        }

        /// <summary>
        /// Takes a string and removes characters that are not letters and stores it in an array.
        /// </summary>
        /// <param name="textFile">The textfile that will be turned into an array.</param>
        /// <returns>array with unwanted characters removed, words separated with a space.</returns>
        public static string[] TurnTextFileToArray(string textFile)
        {
            textFile = Regex.Replace(textFile.ToLower().Trim(), @"[\t]", " ");
            textFile = Regex.Replace(textFile, @"[^a-z\s]", "");
            return textFile.Split(" ");
        }
        
        public static void SearchForAWord()
        {
            Console.Write("\n\tEnter a word to search for: ");
            var searchWord = Console.ReadLine().ToLower().Trim();
            Console.WriteLine($"\tThe word '{searchWord}' was found: ");
            for (int i = 0; i < textFiles.Length; i++)
            {
                var matchingWords = textFiles[i].Where(x => x == searchWord);
                var amount = matchingWords.Count();
                var times = amount == 1 ? "time" : "times";
                Console.WriteLine($"\t{amount} {times} in textfile {i + 1}");
                Console.ReadKey();
            }

            Console.ReadKey();
        }
    }
}
