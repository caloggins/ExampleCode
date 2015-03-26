namespace TddExamples.Naming
{
    using System;
    using System.Collections.Generic;

    // domain language stuff here...
    public class Parsers : Dictionary<Func<string, bool>, Parser>
    {

    }
}