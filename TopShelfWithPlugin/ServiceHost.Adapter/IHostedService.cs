namespace ServiceHost.Adapter
{
    public interface IHostedService
    {
        void Start();

        void Stop();

        void Pause();

        void Continue();
    }
}