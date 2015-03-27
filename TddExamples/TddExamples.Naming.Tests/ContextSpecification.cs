namespace TddExamples.Naming.Tests
{
    using System;
    using System.Reflection;
    using NUnit.Framework;

    /// <summary>
    /// Base class for BDD-style tests.
    /// </summary>
    /// <remarks>
    /// Taken from: http://blogs.msdn.com/b/elee/archive/2009/01/20/bdd-with-mstest.aspx
    /// See also: http://dannorth.net/introducing-bdd/
    /// </remarks>
    public abstract class ContextSpecification
    {
        protected Exception CapturedException;

        [SetUp]
        public void TestInitialize()
        {
            Context();
            try
            {
                BecauseOf();
            }
            catch (TargetInvocationException exception)
            {
                CapturedException = exception.InnerException;
            }
            catch (Exception exception)
            {
                CapturedException = exception;
            }
        }

        [TearDown]
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