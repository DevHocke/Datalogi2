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
    }
}
