using System.Collections.Generic;

namespace TestingProtectedStuff.ImportedLibrary
{
    public abstract class BaseClass
    {
        protected abstract IEnumerable<string> DoSomething(string input);
    }
}