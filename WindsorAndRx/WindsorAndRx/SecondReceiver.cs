namespace WindsorAndRx
{
    using Castle.Core.Logging;

    public class SecondReceiver : IHandle<DidIt>
    {
        private readonly ILogger logger;

        public SecondReceiver(ILogger logger)
        {
            this.logger = logger;
        }

        public void Handle(DidIt @event)
        {
            var s = string.Format("Received message {0}", @event.Messsage);
            logger.Info(s);
        }
    }
}