namespace PolyMap
{
    public interface IPublisher
    {
        void Publish(Command command);
    }
}