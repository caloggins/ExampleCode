namespace TddExamples.Naming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Parser
    {
        public static Parser Default { get { return new DefaultParser(); } }

        public static Parser Empty { get { return new EmptyParser(); } }

        public static Parser Single { get { return new SingleParser(); } }

        public static Parser Multiple { get { return new MultipleParser(); } }

        public abstract IEnumerable<int> Parse(string numbers);

        private class EmptyParser : Parser
        {
            public override IEnumerable<int> Parse(string numbers)
            {
                yield return 0;
            }
        }

        private class SingleParser : Parser
        {
            public override IEnumerable<int> Parse(string numbers)
            {
                yield return int.Parse(numbers);
            }
        }

        private class MultipleParser : Parser
        {
            public override IEnumerable<int> Parse(string numbers)
            {
                return numbers.Split(',')
                    .Select(int.Parse);
            }
        }

        private class DefaultParser : Parser
        {
            public override IEnumerable<int> Parse(string numbers)
            {
                throw new ArgumentException("Unable to parse string.");
            }
        }
    }
}