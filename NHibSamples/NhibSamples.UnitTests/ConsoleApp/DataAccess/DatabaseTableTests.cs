namespace NhibSamples.UnitTests.ConsoleApp.DataAccess
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NhibSamples.ConsoleApp.DataAccess;

    public static class DatabaseTableTests
    {
        [TestClass]
        public class DatabaseTableSpecs
        {
            [TestMethod]
            public void ItShouldDefineTheOrdersTable()
            {
                DatabaseTable.CustomerOrders.Should().Be("CustomerOrders");
            }

            [TestMethod]
            public void ItShouldDefineTheProductsTable()
            {
                DatabaseTable.Products.Should().Be("Products");
            }
        }
    }
}