namespace TddExamples.Naming
{
    using System.Linq;

    public class Widget
    {
        private readonly IGetParser parsers;

        public Widget(IGetParser parsers)
        {
            this.parsers = parsers;
        }

        public int Add(string input)
        {
            var parser = parsers.Get(input);

            var numbers = parser.Parse(input);

            return numbers.Sum();
        }
    }
}