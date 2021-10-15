using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Datalogi2
{
    class App
    {
        public void Start()
        {
            var array1 = TurnTextFileToArray(GetTextFile("Text_1.txt"));
            var array2 = TurnTextFileToArray(GetTextFile("Text_2.txt"));
            var array3 = TurnTextFileToArray(GetTextFile("Text_3.txt"));
            Menu.MainMenu();
        }

        public static string GetTextFile(string fileName)
        {
            return File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
        }

        public static string[] TurnTextFileToArray(string textFile)
        {
            var array = textFile.Split(" ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Regex.Replace(array[i], @"[^\w]", "");
            }

            return array;
        }
    }
}
