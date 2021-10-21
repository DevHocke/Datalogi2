using System;
using System.Collections.Generic;
using System.Text;

namespace Datalogi2
{
    class Search
    {
        public string Word { get; set; }
        public string[] Results { get; set; }

        public Search(string word)
        {
            Word = word;
        }


    }
}
