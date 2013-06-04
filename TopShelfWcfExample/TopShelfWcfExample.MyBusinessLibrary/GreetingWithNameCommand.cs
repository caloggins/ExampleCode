namespace TopShelfWcfExample.MyBusinessLibrary
{
    public class GreetingWithNameCommand
    {
        public string Name { get; set; }

        public virtual string Execute()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new MyCustomException("A valid name was not provided.");

            return string.Format("Hello, {0}.", Name);
        }
    }
}