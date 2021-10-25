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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n\t{Word} was found:");
            foreach (var result in Results)
            {
                sb.AppendLine(result);
            }

            return sb.ToString();
        }
    }
}
