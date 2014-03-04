namespace TopShelfWcfExample.MyBusinessLibrary.UnitTests
{
    using System.Linq;
    using Castle.Windsor;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class BusinessLibraryInstallerTests
    {
        [TestClass]
        public class WhenTheInstallerHasBeenUsed
        {
            [TestMethod]
            public void TheGreetingWithNameCommandShouldBeRegistered()
            {
                var container = new WindsorContainer();
                var sut = InstallerFactory();

                container.Install(sut);

                var allTypes = WindsorTestHelpers.GetPublicClassesFromApplicationAssemblyContaining<GreetingWithNameCommand>(
                        type => type == typeof (GreetingWithNameCommand)).ToList();
                var registeredTypes = container.GetImplementationTypesFor<GreetingWithNameCommand>();
                registeredTypes.Should().BeEquivalentTo(allTypes);
                registeredTypes[0].ShouldBeEquivalentTo(allTypes[0], options => options.ExcludingNestedObjects());
            }

            private BusinessLibraryInstaller InstallerFactory()
            {
                return new BusinessLibraryInstaller();
            }
        }
    }
}