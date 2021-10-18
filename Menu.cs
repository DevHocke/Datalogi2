﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Datalogi2
{
    class Menu
    {
        public static void MainMenu()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n\tWhat do you want to do?");
                Console.WriteLine("\n\t1. Search for a word.");
                Console.WriteLine("\t2. Print data structure.");
                Console.WriteLine("\t3. Print first x words in alphabetic order.");
                Console.WriteLine("\t4. Exit.");
                Console.Write("\t> ");
                int.TryParse(Console.ReadLine(), out var choice);
                switch (choice)
                {
                    case 1:
                        App.SearchForAWord();
                        break;
                    case 2:
                        PrintDataStructure();
                        break;
                    case 3:
                        PrintWordsAlphabetically();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\tInvalid input! Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void PrintDataStructure()
        {
        }

        private static void PrintWordsAlphabetically()
        {
        }

    }
}
