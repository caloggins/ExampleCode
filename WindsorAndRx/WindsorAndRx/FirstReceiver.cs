namespace WindsorAndRx
{
    using Castle.Core.Logging;

    public class FirstReceiver : IHandle<DidIt>
    {
        private readonly ILogger logger;

        public FirstReceiver(ILogger logger)
        {
            this.logger = logger;
        }

        public void Handle(DidIt @event)
        {
            logger.Info(string.Format("Received event with message {0}", @event.Messsage));
        }
    }
}