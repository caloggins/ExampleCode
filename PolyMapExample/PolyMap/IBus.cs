namespace PolyMap
{
    public interface IBus
    {
        void Publish<T>(T message) where T : class;
    }
}