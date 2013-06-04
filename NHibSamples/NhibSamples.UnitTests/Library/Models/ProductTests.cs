namespace NhibSamples.UnitTests.Library.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NhibSamples.Library.Models;

    public static class ProductSpecs
    {
        [TestClass]
        public class ToStringOverride
        {
            [TestMethod]
            public void WithValidProperties()
            {
                const string expectedResult = "Product <Id: 42, Name: Coke>";
                var sut = new Product
                              {
                                  ProductId = 42L,
                                  Name = "Coke",
                              };

                var result = sut.ToString();

                result.Should().Be(expectedResult);
            }
        }
    }
}