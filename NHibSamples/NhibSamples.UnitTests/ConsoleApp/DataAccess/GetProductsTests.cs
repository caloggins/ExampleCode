namespace NhibSamples.UnitTests.ConsoleApp.DataAccess
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NhibSamples.Library.Models;

    public static class GetProductsTests
    {
        [TestClass]
        public class SampleDbTest : DatabaseContext
        {
            protected long Id;

            protected override void Context()
            {
                using (var tx = ContextSession.BeginTransaction())
                {
                    var product = new Product
                                      {
                                          Name = "Coke",
                                          Type = ProductType.Soda,
                                          IsActive = true,
                                      };
                    
                    Id = (long)ContextSession.Save(product);
                    tx.Commit();
                }

                ContextSession.Get<Product>(Id);
            }

            private Product result;

            protected override void BecauseOf()
            {
                result = ContextSession.Get<Product>(Id);
            }

            [TestMethod]
            public void ItShouldReturnTheResults()
            {
                result.Name.Should().Be("Coke");
            }
        }
    }
}