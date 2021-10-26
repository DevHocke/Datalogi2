using System;

namespace Datalogi2
{
    static class Color
    {
        /// <summary>
        /// Prints a text in blue to the console.
        /// </summary>
        /// <param name="str">The string to print.</param>
        public static void InBlue(string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints a text in red to the console.
        /// </summary>
        /// <param name="str">The string to print.</param>
        public static void InRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints a text in green to the console.
        /// </summary>
        /// <param name="str">The string to print.</param>
        public static void InGreen(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Gets the user input in blue.
        /// </summary>
        /// <returns>The user input.</returns>
        public static string Getinput()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            var input = Console.ReadLine().Trim();
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
    }
}
