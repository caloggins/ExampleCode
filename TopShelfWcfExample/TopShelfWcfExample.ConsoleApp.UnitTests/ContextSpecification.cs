namespace TopShelfWcfExample.ConsoleApp.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Base class for BDD-style tests.
    /// </summary>
    /// <remarks>
    /// Taken from: http://blogs.msdn.com/b/elee/archive/2009/01/20/bdd-with-mstest.aspx
    /// See also: http://dannorth.net/introducing-bdd/
    /// </remarks>
    public abstract class ContextSpecification
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitizlize()
        {
            Context();
            BecauseOf();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Cleanup();
        }

        protected virtual void Context()
        {

        }

        protected virtual void BecauseOf()
        {

        }

        protected virtual void Cleanup()
        {

        }
    }
}