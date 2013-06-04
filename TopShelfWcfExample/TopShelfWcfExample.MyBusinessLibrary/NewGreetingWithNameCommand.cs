namespace TopShelfWcfExample.MyBusinessLibrary
{
    public class NewGreetingWithNameCommand
    {
        public string Name { get; set; }

        public virtual string Execute()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new MyCustomException("A valid name was not provided.");

            return string.Format("Goodbye, {0}.", Name);
        }
    }
}