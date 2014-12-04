namespace WindsorTypedFactory.Library
{
    using System;

    public class Stop : Command
    {
        public override void Execute()
        {
            Console.WriteLine("Stop!!");
        }
    }
}