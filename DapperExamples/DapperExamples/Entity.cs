namespace DapperExamples
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
}