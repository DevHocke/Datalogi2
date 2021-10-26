using System;
using System.Text;

namespace Datalogi2
{
    class Search
    {
        public string Word { get; set; }
        public string[] Results { get; set; } = new string[App.Size];

        public Search(string word)
        {
            Word = word;
        }

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
