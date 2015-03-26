namespace TddExamples.Naming
{
    using System;
    using System.Linq;

    // interface segregation
    public class ParserMap : IGetParser, ISetParser
    {
        private readonly Parsers parsers = new Parsers();

        public ParserMap()
        {
            // chain of responsibility, so order is important
            parsers.Add(s => s == "", Parser.Empty);
            parsers.Add(s => s.Contains(","), Parser.Multiple);
            parsers.Add(s => s.Length == 1, Parser.Single);
            parsers.Add(s => true, Parser.Default);
        }

        public Parser Get(string input)
        {
            var parser = (from p in parsers
                where p.Key(input)
                select p.Value)
                .First();

            return parser;
        }

        public void Set(Parser parser)
        {
            throw new NotImplementedException();
        }
    }
}