namespace WindsorTypedFactory.Library
{
    using System;

    public class Start : Command
    {
        public override void Execute()
        {
            Console.WriteLine("Start!!");
        }
    }

    public class FirstStartHandler : IHandle<Start>
    {
        public void Handle(Start command)
        {
            command.Execute();
        }
    }

    public class SecondStartHandler : IHandle<Start>
    {
        public void Handle(Start command)
        {
            command.Execute();
        }
    }
}