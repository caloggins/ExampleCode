// ReSharper disable UnusedMember.Global
namespace MoveEventProcessor
{
    public class Processor
    {
        private readonly IListener[] listeners;

        public Processor(IListener[] listeners)
        {
            this.listeners = listeners;
        }

        public void Start()
        {
            foreach (var listener in listeners)
                listener.Start();
        }
    }
}