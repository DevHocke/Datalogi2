using System;

namespace Datalogi2
{
    class Search
    {
        /// <summary>
        /// The search word.
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// An array with the results from the search.
        /// </summary>
        public string[] Results { get; set; } = new string[App.Size];

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="word">The search word.</param>
        public Search(string word)
        {
            Word = word;
        }

        /// <summary>
        /// Prints the search word and the results to the console.
        /// </summary>
        public void Print()
        {
            Console.Write("\n\tThe Word ");
            Color.InBlue(Word);
            Console.WriteLine(" was found:");
            foreach (var result in Results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
