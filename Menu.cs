using System;

namespace Datalogi2
{
    class Menu
    {
        public void MainMenu()
        {
            var app = new App();
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n\tWhat do you want to do?");
                Console.WriteLine("\n\t1. Search for a word.");
                Console.WriteLine("\t2. Print binary tree.");
                Console.WriteLine("\t3. Print first x words in alphabetic order.");
                Console.WriteLine("\t4. Exit.");
                Console.Write("\t> ");
                int.TryParse(Color.Getinput(), out var choice);
                switch (choice)
                {
                    case 1:
                        app.SearchForAWord();
                        break;
                    case 2:
                        app.TraverseBinaryTree();
                        break;
                    case 3:
                        app.PrintWordsAlphabetically();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Color.InRed("\tInvalid input! Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
