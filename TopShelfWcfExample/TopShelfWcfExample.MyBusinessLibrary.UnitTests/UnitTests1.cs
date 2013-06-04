namespace TopShelfWcfExample.MyBusinessLibrary.UnitTests
{
    public static class UnitTests1Tests
    {
        public class UnitTests1Context : ContextSpecification
        {
            protected UnitTests1 Sut;

            protected override void Context()
            {
                base.Context();

                Sut = new UnitTests1();
            }
        }
    }

    public class UnitTests1
    {
    }
}