namespace SamplePlugin
{
    using Castle.Core.Logging;

    using ServiceHost.Adapter;

    public class SamplePlugin : IHostedService
    {
        private readonly ILogger logger;

        public SamplePlugin(ILogger logger)
        {
            this.logger = logger;
        }

        public void Start()
        {
            logger.Info("Sample plug-in started.");
        }

        public void Stop()
        {
            logger.Info("Sample plug-in stopped.");
        }

        public void Pause()
        {
        }

        public void Continue()
        {
        }
    }
}
