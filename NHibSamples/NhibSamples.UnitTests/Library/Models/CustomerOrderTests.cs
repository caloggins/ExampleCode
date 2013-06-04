namespace NhibSamples.UnitTests.Library.Models
{
    using System;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NhibSamples.Library.Models;

    public static class CustomerOrderSpecs
    {
        [TestClass]
        public class ToStringOverride
        {
            [TestMethod]
            public void WithValidProperties()
            {
                const string expectedResult = "Customer Order <Id: 42, Date Placed: 02/01/2012>";
                var sut = new CustomerOrder
                              {
                                  OrderId = 42L,
                                  DatePlaced = new DateTime(2012, 02, 01)
                              };

                var result = sut.ToString();

                result.Should().Be(expectedResult);
            }
        }
    }
}